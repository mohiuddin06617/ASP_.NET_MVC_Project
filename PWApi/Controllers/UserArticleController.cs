using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PWService;
using PWEntity;
using PWApi.Attributes;
using System.Threading;
using System.Security.Principal;

namespace PWApi.Controllers
{

    public class UserArticleController : ApiController
    {
        ArticleService articleService = new ArticleService();
        UserDetailService userDetailService = new UserDetailService();
        //[AllowAnonymous]
        public IHttpActionResult Get()
        {

            //return Ok(articleService.AllArticleList(userId));
            return Ok(articleService.GetAll());
        }
        //[BasicAuthentication]
        [Route("api/UserArticles/{key}")]
        public IHttpActionResult Get(string key)
        {
            int userId = userDetailService.UserIdByApiKey(key);
            if (userId != 0)
            {
                return Ok(articleService.AllArticleList(userId));
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserArticle/5
        public IHttpActionResult Post([FromBody]Article article)
        {
            articleService.Insert(article);
            return Created(Url.Link("Get", new { id = article.Id }), article);

            //return Content(HttpStatusCode.Created,Url.Link("Get",new { id?=>article.Id}));
        }

        // PUT: api/UserArticle/5
        public IHttpActionResult Put([FromUri]int id, [FromBody]Article article)
        {
            article.Id = id;
            articleService.Update(article);
            return Ok(article);
        }

        // DELETE: api/User/5
        public IHttpActionResult Delete(int id)
        {
            int stat=articleService.DeleteArticle(id);
            if (stat!=0)
            {
                return Ok();
            }
            return StatusCode(HttpStatusCode.NoContent);

        }
        [HttpGet]
        [Route("api/UserArticles/{key}/Search/{query}")]
        public IHttpActionResult Search([FromUri]string key, [FromUri]string query)
        {
            List<Article> allList = articleService.GetAll().Where(a => a.subject.Contains(query)).ToList();

            if (allList != null)
            {
                return Ok(allList);
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
