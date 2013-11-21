using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingSite.Controllers
{
    public class MemberPageController : Controller
    {
        //
        // GET: /MemberPage/

        public ActionResult Index()
        {
            ViewBag.Username = TempData["Username"];
            ViewBag.Password = TempData["Password"]; 
            

            return View();
        }

        
    }
}
