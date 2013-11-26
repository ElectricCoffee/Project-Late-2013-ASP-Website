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
            return View();
        }

        [HttpPost, ActionName("Do")]

        public ActionResult Register()
        {
            var firstname = Request.Form["Firstname"];
            var lastname = Request.Form["Lastname"];
            var email = Request.Form["Email"];
            var password = Request.Form["Password"];
            var homeroom = Request.Form["Homeroom"];

            var uri = string.Format(
                "http://localhost:14781/api/registeruser?firstname={0}&lastname={1}&emal={2}&password={3}&homeroomClass={4}", 
                firstname, lastname, email, password, homeroom);

            var response = ServerCommunicator.Get(uri).DeserializeJson<RestResponseContainer>();

            if (response.Key.Contains("Error"))
            {
                TempData["Message"] = "Der kunne desværre ikke blive oprettet en bruger i systemet," +
                    " da de indtastede oplysninger var forkerte, vær venlig at prøve igen";
            }
            else TempData["Message"] = "Tillykke, du er nu oprettet, vent på at din lærer har godkendt det.";

            return new RedirectResult("/RegisterUser/ResponsePage");
        }
    }
}
