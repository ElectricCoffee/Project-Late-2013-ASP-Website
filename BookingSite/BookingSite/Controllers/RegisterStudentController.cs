using BookingSite.Models;
using BookingSite.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BookingSite.Controllers
{
    public class RegisterStudentController : Controller
    {
        //
        // GET: /RegisterUser/

        public ActionResult Index()
        {
            ViewBag.Title = "Registrer ny bruger";
            return View();
        }

        /// <summary>
        /// Gets a response from the rest server based on the user's credentials, and returns an error or a positive message accordingly
        /// </summary>
        /// <returns></returns>
        [HttpPost, ActionName("Do")]
        public ActionResult Register()
        {
            Action<String> message = str => TempData["Message"] = str;

            ///*
            // These are the values gotten from the input fields on the web-page.
            var firstname = Request.Form["Firstname"];
            var lastname  = Request.Form["Lastname"];
            var username  = Request.Form["Email"];
            var repeat    = Request.Form["Repeat"];
            var password  = Request.Form["Password"];
            var homeroom  = Request.Form["Homeroom"];

            // if the password and the repeated password don't match, then you aren't allowed to even connect to the REST server.
            if (password.Equals(repeat))
            {

                var uri = "http://localhost:14781/api/registerstudent";

                Student student = new Student {
                    HomeRoomClass = new HomeRoomClass {Name = homeroom},
                    Password = password,
                    Username = username,
                    Name = new Name {FirstName = firstname, LastName = lastname},
                    Approved = false
                };

                try
                {
                    ServerCommunicator.Post(uri, student.SerializeToJsonObject());
                }
                catch (WebException we)
                {
                    Debug.WriteLine(we.Message);
                }
            }
            else message("Du har tastet din adgangskode forkert, prøv igen.");

            return new RedirectResult("/RegisterStudent/ResponsePage");
        }

        [ActionName("ResponsePage")]
        public ActionResult ResponsePage()
        {
            return View();
        }
    }
}
