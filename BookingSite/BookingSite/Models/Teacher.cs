using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSite.Models
{
    public class Teacher
    {
        public Name Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
    }
}