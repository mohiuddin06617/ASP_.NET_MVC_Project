using PWEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PWService;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace PortfolioWebsite.Controllers
{
    public class UserController : Controller
    {
        UserDetailService userDetailService = new UserDetailService();

        public ActionResult Home()
        {
            return View();
        }
        // GET: User
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                int id = Convert.ToInt32(Session["UserId"]);
                return View(userDetailService.Get(id));
            }
            else
            {
                return RedirectToAction("Index", "Article", null);
            }
            
           
        }
        public ActionResult Login()
        {
            if (Session["UserId"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Article", null);
            }
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(UserDetail userDetail)
        //{
        //    bool status = false;
        //    if (userDetail.Email!=null && userDetail.Password!=null)
        //    {
        //        status = userDetailService.Login(userDetail.Email, userDetail.Password);
        //        if (status==true)
        //        {
        //            //var ticket=FormsAuthenticationTicket()
        //            return RedirectToAction("Index", "Article", null);
        //        }
        //        else
        //        {
        //            ViewBag.LoginFailed = "Invalid Email or Password";
        //        }
        //    }
        //    return View();
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserDetail userDetail)
        {

            int UserId = 0;
            if (userDetail.Email != null && userDetail.Password != null)
            {
                UserId = userDetailService.Login(userDetail.Email, userDetail.Password);
                if (UserId != 0)
                {
                    Session["UserId"] = UserId;
                    return RedirectToAction("Index", "Article", null);
                }
                else
                {
                    ViewBag.LoginFailed = "Invalid Email or Password";
                }
            }
            return View();

        }
        public ActionResult UserDetails()
        {
            if (Session["UserId"] != null)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                return View("Details",userDetailService.Get(userId));
            }
            return RedirectToAction("Logout");
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            if (Session["UserId"] != null)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                return View(userDetailService.Get(id));
            }
            return RedirectToAction("Logout");
        }

        // GET: User/Create
        public ActionResult Create()
        {
            if (Session["UserId"] != null)
            {
                return RedirectToAction("Logout");
            }
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserDetail userDetail)
        {
            if (ModelState.IsValid)
            {
                if (!userDetailService.IsEmailExist(userDetail.Email))
                {
                    //userDetail.Password = userDetailService.HasherFunc(userDetail.Password);
                    //MailAddress address = new MailAddress(userDetail.Email);
                    userDetail.ApiAccessUserName = userDetail.Email.Split('@')[0];
                    userDetailService.Insert(userDetail);
                    ViewBag.RegistrationSuccess = "You have successfully registered ! You can login now!";
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("EmailExist", "Already have a account of this email");
                    return View();
                }
            }
            return View();
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {

            if (Session["UserId"] != null)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                return View(userDetailService.Get(id));
            }
            return RedirectToAction("Logout");
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(UserDetail userDetail)
        {
            if (Session["UserId"] != null)
            {
                try
                {
                    userDetail.Id = Convert.ToInt32(Session["UserId"]);
                    // TODO: Add update logic here
                    userDetailService.Update(userDetail);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("Logout");
        }

        // GET: User/Delete/5
        public ActionResult Delete()
        {
            if (Session["UserId"] != null)
            {
                int id = Convert.ToInt32(Session["UserId"]);
                return View(userDetailService.Get(id));
            }
            return RedirectToAction("Logout");
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(UserDetail userDetail)
        {
            if (Session["UserId"] != null)
            {
                try
                {
                    userDetailService.Delete(userDetail);
                    TempData["SuccessfullyDeleted"] = "Your Data have been successfully deleted";
                    return RedirectToAction("Logout");
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("Logout");

        }
        public ActionResult Logout()
        {
            if (Session["UserId"] != null)
            {
                Session.Remove("UserId");
                return RedirectToAction("Login", "User");

            }
            return RedirectToAction("Login", "User", null);
        }
    }
}
