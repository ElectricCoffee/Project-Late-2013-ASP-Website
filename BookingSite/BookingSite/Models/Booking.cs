using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSite.Models
{
    public class Booking 
    {
        public int Id { get; private set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Subject Subject { get; set; }
    }
}