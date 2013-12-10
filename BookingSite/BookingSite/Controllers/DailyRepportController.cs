using BookingSite.Utils;
using BookingSite.Models;
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

        private const string SERVER_URI = "http://localhost:14781/api/";

        public ActionResult Index()
        {
            var concreteBookings = ServerCommunicator.Get(SERVER_URI + "concretebooking").DeserializeJson<ConcreteBooking[]>();

            var dates = new List<DateTime>();

            foreach (var cb in concreteBookings)
            {
                if (cb.Subject.Teacher.Username.Equals("kbr"))
                    dates.Add(cb.StartTime);
            }

            return List(concreteBookings, dates);
        }

        public ActionResult List(IEnumerable<ConcreteBooking> concreteBookings, IEnumerable<DateTime> dates)
        {
            ViewBag.Bookings = concreteBookings;
            ViewBag.Dates = dates;

            return View("Index");
        }

        [HttpPost, ActionName("Filter")]
        public ActionResult GetDailyRepport()
        {
            var concreteBookings = ServerCommunicator.Get(SERVER_URI + "concretebooking").DeserializeJson<ConcreteBooking[]>();
            var dates = new List<DateTime>();
            foreach (var cb in concreteBookings)
            {
                if (cb.Subject.Teacher.Username.Equals("kbr"))
                    dates.Add(cb.StartTime);
            }

            var date = DateTime.Parse(Request.Form["date"]);
            var currentBookings = concreteBookings.Where(cb => cb.StartTime == date);

            return List(currentBookings, dates);
        }
    }
}
