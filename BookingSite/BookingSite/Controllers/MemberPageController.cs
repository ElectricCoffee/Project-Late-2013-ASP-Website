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
            ViewBag.Response = TempData["Response"];
            ViewBag.Access = TempData["Access"];
            ViewBag.UID = TempData["UID"];
            

            return View();
        }

        
    }
}
