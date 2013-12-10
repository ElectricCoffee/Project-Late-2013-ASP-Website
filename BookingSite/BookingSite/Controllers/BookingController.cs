using BookingSite.Models;
using BookingSite.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingSite.Controllers
{
    public class BookingController : Controller
    {
        private const string SERVER_URI = "http://localhost:14781/api/";
        private string username = "trin123a";

        //
        // GET: /Booking/

        public ActionResult Index()
        {
            var json = ServerCommunicator.Get(SERVER_URI + "concretebooking");
            var concreteBookings = json.DeserializeJson<IEnumerable<Models.ConcreteBooking>>();
            var bookinglist =  concreteBookings.Where(cb => cb.Student.Username.Equals(username));

            ViewBag.BookingList = bookinglist;
            
            return View();
        }

        //
        // GET: /Booking/CreateBooking

        [HttpGet, ActionName("CreateBooking")]
        public ActionResult CreateBooking()
        {
            var possibleBookings = ServerCommunicator.Get(SERVER_URI + "possiblebooking").DeserializeJson<PossibleBooking[]>();
            var subjects         = ServerCommunicator.Get(SERVER_URI + "subject").DeserializeJson<Subject[]>();
            
            ViewBag.Bookings = possibleBookings;
            ViewBag.Subjects = subjects;
           
            return View();
        }

        //
        // POST: /Booking/CreateBooking

        [HttpPost, ActionName("CreateBooking")]
        public ActionResult CreateConcreteBooking()
        {
            var subject = Request.Form["subject"];
            var date    = Request.Form["date"];
            var comment = Request.Form["comment_box"];

            var subjects = ServerCommunicator.Get(SERVER_URI + "subject").DeserializeJson<Subject[]>();
            var possibleBookings = ServerCommunicator.Get(SERVER_URI + "possiblebooking").DeserializeJson<PossibleBooking[]>();

            // check if subject exists
            foreach (var s in subjects) {
                if (subject.Equals(s.Name)) {
                    var subjectId = s.Id;
                    // find the correct possiblebookingid based on the start time and the subject name
                    foreach (var pb in possibleBookings)
                    {
                        if (date.Equals(pb.StartTime.ToString()) && subject.Equals(pb.Subject.Name))
                        {
                            var possibleBookingId = pb.Id;

                            var concreteBooking = new ConcreteBooking();
                            concreteBooking.Type = 0;
                            concreteBooking.Subject = s;
                            var startDate = DateTime.Parse(date);
                            concreteBooking.StartTime = startDate;
                            concreteBooking.EndTime = startDate.AddMinutes(pb.Duration);
                            concreteBooking.Comment = comment;
                            concreteBooking.PossibleBookingId = possibleBookingId;
                            concreteBooking.Student = new Student { Username = username };

                            var json = concreteBooking.SerializeToJsonObject();

                            ServerCommunicator.Post(SERVER_URI + "concretebooking", json);
                        }
                    }
                }
            }

            return new RedirectResult("Index");
        }

        [HttpDelete, ActionName("DeleteBooking")]
        public ActionResult Delete(string id)
        {
            Debug.WriteLine("Received ID: " + id);

            ServerCommunicator.Delete(SERVER_URI + "concretebooking/" + id);

            return Index();
        }
    }
}
