  using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PWService;
using PWRepository;
using PWEntity;
using PWApi.Attributes;

namespace PWApi.Controllers
{
    
    public class UserController : ApiController
    {
        ArticleService articleService = new ArticleService();
        //DataAccessContext dataAccess = new DataAccessContext();
        // GET: api/User
        
        public IHttpActionResult Get()
        {
            //return Ok(articleService.AllArticleList(userId));
            return Ok(articleService.GetAll());
        }

        //GET: api/User/5
        public IHttpActionResult Get(int id)
        {
            return Ok(articleService.AllArticleList(id));
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
