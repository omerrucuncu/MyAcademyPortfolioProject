using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPortfolio.Controllers
{
    [AllowAnonymous] // Allow access to all users, including unauthenticated ones
    public class LoginController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index (TblAdmins admins)
        {
            var admin = new MyAcademyPortfolioProjectEntities().TblAdmins.Where(x => x.UserName == admins.UserName && x.Password == admins.Password).FirstOrDefault();
            if (admin != null)
            {
                FormsAuthentication.SetAuthCookie(admin.UserName, false);
                Session["UserName"] = admin.UserName;
                
                return RedirectToAction("Index", "About");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }
            
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Default");
        }
    }

    //public class SessionTimeoutAttribute : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        var session = filterContext.HttpContext.Session;
    //        if (session != null && session["UserName"] == null)
    //        {
    //            filterContext.Result = new RedirectResult("~/Login/Index");
    //        }
    //        base.OnActionExecuting(filterContext);
    //    }
    //}

    //// Step 3: Apply the filter to controllers/actions that require authentication.

    //[SessionTimeout]
    //[Authorize]
    //public class SomeProtectedController : Controller
    //{
    //    // Your protected actions here
    //}
}

