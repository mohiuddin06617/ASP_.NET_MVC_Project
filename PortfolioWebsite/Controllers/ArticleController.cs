using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PWService;
using PWEntity;
using PWEntity.ViewModels;
using PortfolioWebsite.App_Start;

namespace PortfolioWebsite.Controllers
{
    public class ArticleController : Controller
    {
        IArticleService articleService;
        //ICategoryService categoryService;
        ArticleCommentService articleCommentService = new ArticleCommentService();
        public ArticleController()
        {
            articleService = Injector.Container.Resolve<IArticleService>();
            //articleCommentService = Injector.Container.Resolve<IArticleCommentService>();
            //categoryService = Injector.Container.Resolve<ICategoryService>;

        }
        // GET: Article
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                return View(this.articleService.AllArticleList(userId));
            }
            return RedirectToAction("Logout", "User", null);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["UserId"] != null)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                ICategoryService categoryService = new CategoryService();
                var categoryList = categoryService.GetAllCategoryName(userId);
                var articleViewModel = new ArticleViewModel
                {
                    Categories = categoryList
                };
                return View(articleViewModel);
            }
            return RedirectToAction("Logout", "User", null);
        }
        [HttpPost, ActionName("Create"), ValidateInput(false)]
        public ActionResult CreateArticle(ArticleViewModel articleViewModel)
        {
            articleViewModel.Article.UserId = Convert.ToInt32(Session["UserId"]);
            this.articleService.Insert(articleViewModel.Article);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["UserId"] != null)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                return View(this.articleService.Get(id));
            }
            return RedirectToAction("Logout", "User", null);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                article.UserId = userId;
                this.articleService.Update(article);
                return RedirectToAction("Index");
            }
            else
            {
                return View(article);
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            /* ArticleComment comments = repoArticleComment.Get(id);*/
            /* ViewBag.CommentLists = repoArticleComment.Get(id);*/
            /*ViewData["comments"] = repoArticleComment.GetAll(id);*/
            if (Session["UserId"] != null)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                var Comments = articleCommentService.GetAllComment(id);
                var articleDetails = articleService.Get(id);
                ArticleDetailViewModel articleDetailViewModel = new ArticleDetailViewModel
                {
                    Article = articleDetails,
                    ArticleComments = Comments
                    
                };
                return View(articleDetailViewModel);
            }
            return RedirectToAction("Logout", "User",null);     
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["UserId"] != null)
            {
                return View(this.articleService.Get(id));
            }
            return RedirectToAction("Logout", "User");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(Article article)
        {
            if (Session["UserId"] != null)
            {
                this.articleService.Delete(article);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Logout", "User");
        }

        [HttpPost]
        public string PostComment(string commentorName, string commentorEmail, string comment, int articleId)
        {
            /*if (ModelState.IsValid)
            {
                /*this.repoArticleComment.Insert();
                return RedirectToAction("Details","Article",null);
                return View("Details");#1#
               
            }
            else
            {
                return View("Details");
            }*/
            ArticleComment articleComment = new ArticleComment
            {
                commenterName = commentorName,
                commenterEmail = commentorEmail,
                comment = comment,
                date = DateTime.Now,
                articleId = articleId
                
            };
            articleCommentService.Insert(articleComment);
            return comment;
        }
        [HttpPost]
        public ActionResult SearchArticle(string searchTerm)
        {
            List<string> searchResult = this.SearchResultList();
            /* var result = from s in searchResult where SqlMethods.Like(s, "%" + searchTerm + "%") select s;*/
            List<string> result = SearchResultList().Where(s => s.Contains(searchTerm)).ToList();
            if (!string.Equals(searchTerm, null, StringComparison.Ordinal))
            {
                return Json(result);
            }
            return Json(result);
        }
        private List<string> SearchResultList()
        {
            //if (Session['userId'] != 0) {
            //    int id = Session["userId"];

            //}

            List<Article> allData = articleService.GetAll();
            List<string> subjectList = new List<string>();
            foreach (var item in allData)
            {
                subjectList.Add(item.subject);
            }
            return subjectList;
        }

        public ActionResult Chat()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            return RedirectToAction("Logout", "User");
        }
    }
}