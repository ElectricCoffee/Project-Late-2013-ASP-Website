using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSite.Models
{
    public enum BookingType
    {
        Pending = 0,
        Approved = 1,
        Finished = 2
    }

    public class ConcreteBooking:Booking
    {
        public int Id { get; set; }
        private byte TypeNum { get; set; }
        public string Comment { get; set; }
        private byte StatusChangedNum { get; set; }
        public int PossibleBookingId { get; set; }
        public int BookingId { get; set; }
        public Student Student { get; set; }

        public BookingType Type
        {
            get
            {
                return (BookingType)TypeNum;
            }
            set
            {
                TypeNum = (byte)value;
            }
        }
        public bool StatusChanged
        {
            get
            {
                if (StatusChangedNum == 1)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    StatusChangedNum = 1;
                else
                    StatusChangedNum = 0;
            }
        }
        
    }
}