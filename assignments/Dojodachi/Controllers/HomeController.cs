using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Dojodachi.Models;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        //for each route this controller is to handle:
        [HttpGet("dojodachi")]     //Http Method and the route
        public IActionResult Index()
        {
            DachiModel MyDachiModel = new DachiModel()
            {
                Name = "DachiOne",
                Fullness = 70,
                Happiness = 45,
                Meals = 3,
                Energy = 85
            };

            string SessionFeed = HttpContext.Session.GetString("SessionFeed");

            string SessionPlay = HttpContext.Session.GetString("SessionPlay");

            string SessionWork = HttpContext.Session.GetString("SessionWork");

            string SessionSleep = HttpContext.Session.GetString("SessionSleep");

            // HttpContext.Session.GetInt32("Fullness");

            // HttpContext.Session.GetInt32("Happiness");

            // HttpContext.Session.GetInt32("Meals");

            // HttpContext.Session.GetInt32("Energy");

            HttpContext.Session.SetObjectAsJson("DachiObject", MyDachiModel);

            return View("Index");
        }

        [HttpPost("dojodachi/feed")]
        public IActionResult Feed()
        {
            HttpContext.Session.SetString("FeedMessage", "You fed your Dachi! +30 Fullness, -1 Meals!");
            return View("Index");
        }

        [HttpGet("play")]
        public IActionResult Play(DachiModel target)
        {
            HttpContext.Session.SetString("PlayMessage", "You Played with your Dachi! +55 Happiness, -25 Energy!");
            return View("Index");
        }

        [HttpGet("work")]
        public IActionResult Work(DachiModel target)
        {
            HttpContext.Session.SetString("WorkMessage", "You worked your Dachi! +2 Meals -10 Energy!");
            return View("Index");
        }

        [HttpGet("sleep")]
        public IActionResult Sleep(DachiModel target)
        {
            HttpContext.Session.SetString("SleepMessage", "Your Dachi is resting! +50 Energy!");
            return View("Index");
        }

        [HttpGet("restart")]
        public IActionResult Restart()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("PageTwo");
        }
    }
}
