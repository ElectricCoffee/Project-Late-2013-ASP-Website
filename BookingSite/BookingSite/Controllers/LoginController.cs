using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BookingSite.Utils;
using BookingSite.Models;

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
            var username = Request.Form["usernameBox"];
            var password = Request.Form["passwordBox"];
            var hashedPassword = String.Format("{0}{1}", username.Hash(HashType.MD5), password).Hash(HashType.SHA256);

            var response = ServerCommunicator.Get("").DeserializeJson<RestResponseContainer>(); 
            
            TempData["Username"] = username;
            TempData["Password"] = hashedPassword;

            return new RedirectResult("/MemberPage/Index");
        }

    }
}
