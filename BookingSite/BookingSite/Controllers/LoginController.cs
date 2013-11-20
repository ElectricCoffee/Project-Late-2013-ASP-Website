using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingSite.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            ViewBag.Title = "Grimt Loginsystem";
            return View();
        }

        // POST: /Login/Index

        [HttpPost, ActionName("Do")]
        public ActionResult Login()
        {
            TempData["Username"] = Request.Form["usernameBox"];
            TempData["Password"] = Request.Form["passwordBox"];

            return new RedirectResult("/MemberPage/Index");
        }

    }
}
