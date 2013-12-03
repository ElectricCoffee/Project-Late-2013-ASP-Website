using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSite.Models
{
    public class Subject
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        private int SemesterId { get; set; }
        private int TeacherId { get; set; }
    }
}