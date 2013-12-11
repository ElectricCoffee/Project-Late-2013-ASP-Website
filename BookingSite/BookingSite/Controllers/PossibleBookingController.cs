using BookingSite.Models;
using BookingSite.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Table = BookingSite.Utils.PossibleBookings.TableMethods;
using Input = BookingSite.Utils.PossibleBookings.InputMethods;

namespace BookingSite.Controllers
{
	public class PossibleBookingController : Controller
	{
	private const string
		POSSIBLE_BOOKING_URI = ServerCommunicator.SERVER_URI + "/possiblebooking",
		ISO8601_FORMAT = "{0}T{1}Z";

		public ActionResult Index()
		{
			Session["Bookings"] = new List<PossibleBooking>();

			var possibleBookings = ServerCommunicator.Get(POSSIBLE_BOOKING_URI).DeserializeJson<List<PossibleBooking>>();

			var now = DateTime.Now;
			var span = new TimeSpan(2,0,0);
			var endDate = now.Add(span);

			possibleBookings.ForEach(pb => (Session["Bookings"] as List<PossibleBooking>).Add(pb));

			ViewBag.Bookings = (Session["Bookings"] as List<PossibleBooking>);

			return View("Index");
		}

		[HttpPost, ActionName("delay")]
		public ActionResult DelayBooking(int id)
		{
			var duration = double.Parse(Request.Form["duration"]);
			var delay = new Messages.Delay { Duration = TimeSpan.FromMinutes(duration) };
			ServerCommunicator.Put(
				POSSIBLE_BOOKING_URI + "/" + id,
				delay.SerializeToJsonObject());
			return Index();
		}

		[HttpPost, ActionName("delete")]
		public ActionResult DeleteBooking()
		{
			return Index(); // placeholder
		}

		[HttpPost, ActionName("input")]
		public ActionResult InputActions()
		{
			var uri = String.Format(POSSIBLE_BOOKING_URI);
			var date = Request.Form["Date"];
			var startTime = Request.Form["StartTime"];
			var endTime = Request.Form["EndTime"];
			var subject = Request.Form["SubjectBox"];

			var possibleBooking = new PossibleBooking
			{
				StartTime = DateTime.Parse(string.Format(ISO8601_FORMAT, date, startTime)),
				EndTime = DateTime.Parse(string.Format(ISO8601_FORMAT, date, endTime)),
				Subject = new Subject { Name = subject}
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
