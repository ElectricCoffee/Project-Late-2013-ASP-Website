using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingSite.Controllers
{
    public class DailyRepportController : Controller
    {
        //
        // GET: /DailyRepport/

        public ActionResult Index()
        {
            List<DateTime> dates = new List<DateTime>();
            dates.Add(DateTime.Now);
            ViewBag.Dates = dates;
            return View();
        }

    }
}
