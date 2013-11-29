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
            Session["Bookings"] = new PossibleBookingList();

            ServerCommunicator.Get("http://localhost:14781/api/possiblebooking").DeserializeJson<PossibleBookingList>();

            var now = DateTime.Now;
            var span = new TimeSpan(2,0,0);
            var endDate = now.Add(span);

            (Session["Bookings"] as PossibleBookingList).CreateBookings(
                new PossibleBooking {
                    Id        = 1,
                    Subject   = "Android", 
                    Date      = now,
                    StartTime = now, 
                    EndTime   = endDate },
                new PossibleBooking {
                    Id        = 2,
                    Subject   = "Design of Applications", 
                    Date = now.Add(new TimeSpan(2, 0, 0, 0)),
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
            var startData = Request.Form["StartBox"];
            var endData = Request.Form["EndBox"];
            var subjectData = Request.Form["SubjectBox"];

            var json = Input.Create(startData, endData, subjectData);

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
            ViewBag.Date = booking.Date;
            ViewBag.StartTime = booking.StartTime;
            ViewBag.EndTime = booking.EndTime;
            return View();
        }
    }
}
