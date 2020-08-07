using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FullWebApp.Models;

namespace FullWebApp.Controllers
{
    public class HomeController : Controller
    {

        // route to home page
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            Person firstPerson = new Person();
            firstPerson.Name = "Knight";
            firstPerson.Location = "Castle";
            firstPerson.Skills = 9000;
            firstPerson.TotalExperience = 1000000;

            return View("Index", firstPerson);
        }

        // route to create a person
        [HttpGet("/game/people/create")]
        public ViewResult CreatePerson()
        {
            return View("CreatePerson");
        }

        // post route for creating people
        [HttpPost("/game/people/create/success")]
        public ViewResult PersonSubmission(Person FromForm)
        {
            if (ModelState.IsValid)
            {
                return View("PersonSubmission", FromForm);
            }
            else
            {
                return CreatePerson();
            }
        }
    }
}
