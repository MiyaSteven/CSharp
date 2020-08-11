using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FullWebApp.Models;
using Microsoft.AspNetCore.Http;

namespace FullWebApp.Controllers
{
    public class HomeController : Controller
    {
        // get route to Home Page
        [HttpGet]
        [Route("")]
        public IActionResult Index()

        {
            // HttpContext.Session.SetString("TestString", "Hello there! General Kenobi...");

            // HttpContext.Session.SetInt32("TestNumber", 9);

            return View("Index");
        }

        // get route to create Person Form
        [HttpGet("/game/people/create")]
        public ViewResult CreatePerson()
        {
            // string testString = HttpContext.Session.GetString("TestString");

            // int? myNum = HttpContext.Session.GetInt32("TestNumber");
            // ViewBag.myNum = myNum;

            Person MyPerson = new Person()
            {
                Name = "FirstPerson"
            };
            HttpContext.Session.SetObjectAsJson("TestObject", MyPerson);

            return View("CreatePerson", MyPerson);
        }

        // post route to display Person created
        [HttpPost("/game/people/success")]
        public ViewResult PersonSubmission(Person FromForm)
        {
            // int? id = HttpContext.Session.GetInt32("UserId");

            // Person fromSession = HttpContext.Session.GetObjectFromJson<Person>("TestObject");

            // ViewBag.MyPerson = fromSession;

            // if (fromSession == null)
            // {
            //     return RedirectToAction("Index");
            // }

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

        [HttpGet("clearsession")]
        public IActionResult ClearSession()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("CreatePerson");
        }
    }
}
