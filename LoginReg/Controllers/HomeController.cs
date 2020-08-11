using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LoginReg.Models;

namespace LoginReg.Controllers
{
    public class HomeController : Controller
    {
        // use foreach eventually for all routes
        [HttpGet("")]
        public ViewResult RegForm()
        {
            return View("RegForm");
        }

        [HttpPost("/success")]
        public ViewResult Profile(RegForm FromForm)
        {
            if (ModelState.IsValid)
            {
                return View("Profile", FromForm);
            }
            else
            {
                return RegForm();
            }
        }
    }
}