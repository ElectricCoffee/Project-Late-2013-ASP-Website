using BookingSite.Models;
using BookingSite.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingSite.Controllers
{
    public class RegisterUserController : Controller
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
            var lastname = Request.Form["Lastname"];
            var email = Request.Form["Email"];
            var repeat = Request.Form["Repeat"];
            var password = Request.Form["Password"];
            var homeroom = Request.Form["Homeroom"];

            // if the password and the repeated password don't match, then you aren't allowed to even connect to the REST server.
            if (password.Equals(repeat))
            {

                var uri = string.Format(
                    "http://localhost:14781/api/registeruser?firstname={0}&lastname={1}&email={2}&password={3}&homeroomClass={4}",
                    firstname, lastname, email, password, homeroom);

                var response = ServerCommunicator.Get(uri).DeserializeJson<RestResponseContainer>();

                if (response.Key.Contains("Error"))
                {
                    message("Der kunne desværre ikke blive oprettet en bruger i systemet," +
                        " da de indtastede oplysninger var forkerte, vær venlig at prøve igen");
                }
                else message("Tillykke, du er nu oprettet, vent på at din lærer har godkendt det.");
                //*/
            }
            else message("Du har tastet din adgangskode forkert, prøv igen.");

            return new RedirectResult("/RegisterUser/ResponsePage");
        }

        [ActionName("ResponsePage")]
        public ActionResult ResponsePage()
        {
            return View();
        }
    }
}
