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
        public ActionResult Index()
        {
            PossibleBookingList bookings = new PossibleBookingList();

            var now = DateTime.Now;
            var span = new TimeSpan(2, 0, 0, 0);
            var endDate = now.Add(span);

            bookings.CreateBookings(
                new PossibleBooking {
                    Checked = false,
                    Subject = "Android", 
                    StartDate = now, 
                    EndDate = endDate },
                new PossibleBooking {
                    Checked = false,
                    Subject = "Design of Applications", 
                    StartDate = now.Add(new TimeSpan(2, 0, 0, 0)), 
                    EndDate = now.Add(new TimeSpan(4, 0, 0, 0)) });

            ViewBag.Bookings = bookings.ReadBookings();

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
            var startData = Request.Form["StartBox"];
            var endData = Request.Form["EndBox"];
            var subjectData = Request.Form["SubjectBox"];

            var json = Input.Create(startData, endData, subjectData);

            ServerCommunicator.Post(uri, json);

            return new RedirectResult(Request.RawUrl);
        }
    }
}
