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
    public class ApproveStudentController : Controller
    {
        private const string SERVER_URI = "http://localhost:14781/api/";

        public ActionResult Index()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student
                {
                    Name = new Name
                        {
                            FirstName = "Trine",
                            LastName = "Thune"
                        }
                });
            ViewBag.Students = students;

            return View();
        }
    }
}
