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
            var students = ServerCommunicator.Get(SERVER_URI + "student").DeserializeJson<Student[]>();
            //Get list of student from REST server

            ViewBag.Students = students;

            return View("Index");
        }

        public ActionResult Approve(int id)
        {
            
            return Index();
        }
    }
}
