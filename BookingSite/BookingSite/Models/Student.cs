using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSite.Models
{
    public class Student : User
    {
        public int Id { get; set; }
        public bool Approved { get; set; }
        public HomeRoomClass HomeRoomClass { get; set; }
        public int UserId { get; set; }
    }
}