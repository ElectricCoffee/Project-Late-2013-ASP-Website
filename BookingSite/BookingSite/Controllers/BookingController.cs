using BookingSite.Models;
using BookingSite.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingSite.Controllers
{
    public class BookingController : Controller
    {
        //
        // GET: /Booking/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet,ActionName ("CreateBooking")]
        public ActionResult CreateBooking()
        {
            var possibleBookings = ServerCommunicator.Get("http://localhost:14781/api/possiblebooking").DeserializeJson<PossibleBookingList>();
            var subjects = ServerCommunicator.Get("http://localhost:14781/api/subject").DeserializeJson<Subject[]>();

            ViewBag.Bookings = possibleBookings.ReadBookings();
            ViewBag.Subjects = subjects;
           
            return View();
        }

        [HttpPost,ActionName("CreateBooking/do")]
        public ActionResult CreateConcreteBooking()
        {
            var subject = Request.Form["subject"];
            var date = Request.Form["date"];
            var comment= Request.Form["comment"];

            ConcreteBooking concreteBooking = new ConcreteBooking();
            var subjects = ServerCommunicator.Get("http://localhost:14781/api/subject").DeserializeJson<Subject[]>();

            int subjectId = 0;

            foreach (var s in subjects) {
                if (subject.Equals(s.Name)) {
                    subjectId = s.Id;
                }
            }

            concreteBooking.Type = 0;
            concreteBooking.SubjectId = subjectId;
            concreteBooking.StartTime = DateTime.Parse(date);
            concreteBooking.Comment = comment;

            return View();
        }

    }
}
