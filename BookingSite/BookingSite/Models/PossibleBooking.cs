using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSite.Models
{
    public class PossibleBookingList
    {
        public List<PossibleBooking> Bookings { get; set; }

        public PossibleBookingList()
        {
            Bookings = new List<PossibleBooking>();
        }
    }

    public class PossibleBooking
    {
        public string Teacher { get; set; }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}