using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSite.Models
{
    public class HomeRoomClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HomeRoomSubject HomeRoomSubject { get; set; }
    }
}