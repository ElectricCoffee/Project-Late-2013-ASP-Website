using BookingSite.Models;
using BookingSite.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingSite.Models;

using Table = BookingSite.Utils.PossibleBookings.TableMethods;
using Input = BookingSite.Utils.PossibleBookings.InputMethods;

namespace BookingSite.Controllers
{
    public class PossibleBookingController : Controller
    {
        private const string ISO8601_FORMAT = "{0}T{1}Z";
        public ActionResult Index()
        {
            Session["Bookings"] = new PossibleBookingList();

            ServerCommunicator.Get("http://localhost:14781/api/possiblebooking").DeserializeJson<IEnumerable<PossibleBooking>>();

            var now = DateTime.Now;
            var span = new TimeSpan(2,0,0);
            var endDate = now.Add(span);

            (Session["Bookings"] as PossibleBookingList).CreateBookings(
                new PossibleBooking {
                    Id        = 1,
                    Subject   = "Android",
                    StartTime = now, 
                    EndTime   = endDate },
                new PossibleBooking {
                    Id        = 2,
                    Subject   = "Design of Applications",
                    StartTime = now.Add(new TimeSpan(2, 0, 0, 0)), 
                    EndTime   = now.Add(new TimeSpan(5,30,0))
                });

            ViewBag.Bookings = (Session["Bookings"] as PossibleBookingList).ReadBookings();

            return View();
        }

        [HttpPost, ActionName("table")]
        public ActionResult DeleteBooking()
        {
            return View(); // placeholder
        }

        [HttpPost, ActionName("input")]
        public ActionResult InputActions()
        {
            var uri = String.Format("http://localhost:14781/api/PossibleBooking");
            var date = Request.Form["Date"];
            var startTime = Request.Form["StartTime"];
            var endTime = Request.Form["EndTime"];
            var subject = Request.Form["SubjectBox"];

            var possibleBooking = new PossibleBooking
            {
                StartTime = DateTime.Parse(string.Format(ISO8601_FORMAT, date, startTime)),
                EndTime = DateTime.Parse(string.Format(ISO8601_FORMAT, date, endTime)),
                Subject = subject
            };

            var json = possibleBooking.SerializeToJsonObject();

            ServerCommunicator.Post(uri, json);

            return new RedirectResult(Request.RawUrl);
        }

        [ActionName("details")]
        public ActionResult DetailPage(string id)
        {
            int i;
            PossibleBooking booking = null;

            if(int.TryParse(id, out i)) {
                booking = (Session["Bookings"] as PossibleBookingList).ReadBookingAtId(i);
            }

            ViewBag.ID = booking.Id;
            ViewBag.Subject = booking.Subject;
            ViewBag.Date = booking.StartTime.Date.ToString();
            ViewBag.StartTime = booking.StartTime.TimeOfDay.ToString();
            ViewBag.EndTime = booking.EndTime.TimeOfDay.ToString();
            return View();
        }
    }
}
