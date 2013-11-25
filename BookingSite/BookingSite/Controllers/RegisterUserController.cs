using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingSite.Controllers
{
    public class RegisterUserController : Controller
    {
        //
        // GET: /RegisterUser/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ActionName("Do")]

        public ActionResult Register()
        {
            var uri = string.Format("http://localhost:14781/api/");
        }
    }
}
