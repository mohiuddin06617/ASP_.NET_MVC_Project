using PWEntity;
using PWService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioWebsite.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService categoryService = new CategoryService();
        // GET: Category
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                return View(categoryService.GetAllCategoryName(userId));
            }
            return RedirectToAction("Logout", "User", null);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            return RedirectToAction("Logout", "User", null);
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (Session["UserId"] != null)
            {
                try
                {
                    // TODO: Add insert logic here
                    int userId = Convert.ToInt32(Session["UserId"]);
                    category.UserId = userId;
                    categoryService.Insert(category);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("Logout", "User", null);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["UserId"] != null)
            {

                return View(categoryService.Get(id));
            }
            return RedirectToAction("Logout", "User", null);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {

            if (Session["UserId"] != null)
            {

                int userId = Convert.ToInt32(Session["UserId"]);
                // TODO: Add update logic here     
                category.UserId = userId;

                if (ModelState.IsValid)
                {
                    categoryService.Update(category);
                    return RedirectToAction("Index");
                }
                return View();

            }
            return RedirectToAction("Logout", "User", null);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["UserId"] != null)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                return View(categoryService.Get(id));
            }
            return RedirectToAction("Logout", "User", null);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            if (Session["UserId"] != null)
            {
                try
                {
                    // TODO: Add delete logic here
                    categoryService.Delete(category);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("Logout", "User", null);
        }
    }
}
