﻿using BookingSite.Models;
using BookingSite.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BookingSite.Controllers
{
    public class ApproveStudentController : Controller
    {
        private const string STUDENT_URI = ServerCommunicator.SERVER_URI +  "student";

        public ActionResult Index()
        {
            // get list of student from REST server
            var students = ServerCommunicator.Get(STUDENT_URI + "?approved=false").DeserializeJson<IEnumerable<Student>>();

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

        //public HttpResponseMessage Count()
        //{
        //    // "http://localhost:14781/api/student/count"

        //    int count = 0xDEAD;

        //    int.TryParse(ServerCommunicator.Get(STUDENT_URI + "/count?approved=false"), out count);

        //    var message =  new HttpResponseMessage();
        //    message.Content = new StringContent(count.ToString());
        //    message.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/plain");

        //    return message;

        //}

        public Int32 Count()
        {
            // "http://localhost:14781/api/student/count"

            int count = 0xDEAD;

            int.TryParse(ServerCommunicator.Get(STUDENT_URI + "/count?approved=false"), out count);

            return count;

        } 
    }
}
