using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSite.Models
{
    public class PossibleBookingList
    {
        private List<PossibleBooking> _bookings = null;

        public PossibleBookingList()
        {
            _bookings = new List<PossibleBooking>();
        }

        public void CreateBookings(params PossibleBooking[] bookings)
        {
            Array.ForEach(bookings, b => CreateBooking(b));
        }

        public void CreateBooking(PossibleBooking booking)
        {
            _bookings.Add(booking);
        }

        public PossibleBooking ReadBookingAtId(int id)
        {
            return _bookings.FirstOrDefault(b => b.Id == id);
        }

        public PossibleBooking ReadBookingAtIndex(int index)
        {
            return _bookings[index];
        }

        public List<PossibleBooking> ReadBookings()
        {
            return _bookings;
        }

        public void UpdateBookings(params Tuple<int, PossibleBooking>[] changes)
        {
            Array.ForEach(changes, c => UpdateBooking(c.Item1, c.Item2));
        }

        public void UpdateBooking(int index, PossibleBooking change)
        {
            _bookings[index] = change;
        }

        public void DeleteBookings(params int[] indexes)
        {
            Array.ForEach(indexes, i => DeleteBooking(i));
        }

        public void DeleteBooking(int index)
        {
            _bookings.RemoveAt(index);
        }
    }

    public class PossibleBooking
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public Subject Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}