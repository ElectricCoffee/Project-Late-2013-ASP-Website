using BookingSite.Utils;
using BookingSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookingSite.Controllers
{
    public class DailyReportController : Controller
    {
        //
        // GET: /DailyRepport/

        private const string ITEM_URI = ServerCommunicator.SERVER_URI + "concretebooking";

        public ActionResult Index()
        {
            var concreteBookings = ServerCommunicator.Get(ITEM_URI).DeserializeJson<IEnumerable<ConcreteBooking>>();

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
            ViewBag.Bookings = concreteBookings.Where(cb => cb.Type != BookingType.Pending);
            ViewBag.PendingBookings = concreteBookings.Where(b => b.Type == BookingType.Pending);
            ViewBag.Dates = dates;

            return View("Index");
        }

        [HttpPost, ActionName("Filter")]
        public ActionResult GetDailyRepport()
        {
            var concreteBookings = ServerCommunicator.Get(ITEM_URI).DeserializeJson<ConcreteBooking[]>();
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

        public ActionResult Finish(int id)
        {
            ServerCommunicator.Put(
                ITEM_URI + "/" + id,
                (new Models.ConcreteBooking { Type = Models.BookingType.Finished }).SerializeToJsonObject());

            return Index();
        }

        public ActionResult Approve(int id)
        {
            ServerCommunicator.Put(
                ITEM_URI + "/" + id,
                new Models.ConcreteBooking { Type = Models.BookingType.Approved }.SerializeToJsonObject());

            return Index();
        }

        public ActionResult Reject(int id)
        {
            ServerCommunicator.Delete(ITEM_URI + "/" + id);
            return Index();
        }
    }
}
