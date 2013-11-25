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
            ViewBag.Title = "EAL Lærerbooking Login";
            return View();
        }

        // POST: /Login/Index

        [HttpPost, ActionName("Do")]
        public ActionResult Login()
        {
            var username = Request.Form["usernameBox"];
            var password = Request.Form["passwordBox"];
            var hashedPassword = String.Format("{0}{1}", username.Hash(HashType.MD5), password).Hash(HashType.SHA256);

            var uri = String.Format("http://localhost:14781/api/login?username={0}&password={1}", username, password); // use to test locally
            //var uri = String.Format("http://92.243.227.143/api/login?username={0}&password={1}", username, password); // use to test un-encrypted
            //var uri = String.Format("http://92.243.227.143/api/Login?Username={0}&Password={1}", username, hashedPassword); // use for the final thing

            var response = ServerCommunicator.Get(uri).DeserializeJson<RestResponseContainer>(); 
            
            TempData["Response"] = response.Key;
            TempData["Access"] = response.Value.Key != null ? response.Value.Key : "";
            TempData["UID"] = response.Value.Value != null ? response.Value.Value : "";

            return new RedirectResult("/MemberPage/Index");
        }

    }
}
