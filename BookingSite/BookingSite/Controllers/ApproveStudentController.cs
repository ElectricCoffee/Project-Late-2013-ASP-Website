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
        private const string STUDENT_URI = ServerCommunicator.SERVER_URI +  "student";

        public ActionResult Index()
        {
            var students = ServerCommunicator.Get(STUDENT_URI).DeserializeJson<Student[]>();
            //Get list of student from REST server

            ViewBag.Students = students;

            return View("Index");
        }

        public ActionResult Approve(int id) //Method to approve students by id
        {
            ServerCommunicator.Put(
                STUDENT_URI + "/" + id,
                new Messages.Approve { Approved = true }.SerializeToJsonObject()); //Sent the student
            return Index(); //Get index
        }

        public ActionResult Reject(int id)
        {
            ServerCommunicator.Delete(STUDENT_URI + "/" + id);

            return Index();
        }
    }
}
