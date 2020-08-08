using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FullWebApp.Models;

namespace FullWebApp.Controllers
{
    public class HomeController : Controller
    {
        // get route to Home Page
        [HttpGet]
        [Route("")]
        public IActionResult Index()

        {
            Person firstPerson = new Person();
            firstPerson.Name = "Knight";
            firstPerson.Location = "Castle";
            firstPerson.Email = "email@email.com";
            firstPerson.Skills = 9000;
            firstPerson.TotalExperience = 1000000;

            return View("Index", firstPerson);
        }

        // get route to create Person Form
        [HttpGet("/game/people/create")]
        public ViewResult CreatePerson()
        {
            return View("CreatePerson");
        }

        // post route to display Person created
        [HttpPost("/game/people/success")]
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

        // get route to create a Message Form
        [HttpGet("/game/people/message/create")]
        public ViewResult CreateMessage()
        {
            DateTime currentTime = DateTime.Now;

            return View("CreateMessage", currentTime);
        }

        // post route to display Message created
        [HttpPost("/game/people/message/success")]
        public ViewResult MessageSubmission(MessageForm FromForm)
        {
            if (ModelState.IsValid)
            {
                return View("MessageSubmission", FromForm);
            }
            else
            {
                return CreateMessage();
            }
        }
    }
}
