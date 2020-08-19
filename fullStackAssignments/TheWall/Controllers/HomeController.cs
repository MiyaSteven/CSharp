using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using TheWall.Models;

namespace TheWall.Controllers
{
    public class HomeController : Controller
    {
        private MyContext DbContext;
        public HomeController(MyContext context)
        {
            DbContext = context;
        }

        [HttpGet("")]
        public ViewResult LoginReg()
        {
            return View("LoginReg");
        }

        [HttpPost("users/register")]
        public IActionResult Register(LoginRegWrapper FromForm)
        {
            if (ModelState.IsValid)
            {
                if (DbContext.Users.Any(u => u.Email == FromForm.Register.Email))
                {
                    ModelState.AddModelError("Register.Email", "This Email exists already. Please Log in.");
                    return LoginReg();
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                FromForm.Register.Password = Hasher.HashPassword(FromForm.Register, FromForm.Register.Password);

                DbContext.Add(FromForm.Register);
                DbContext.SaveChanges();

                HttpContext.Session.SetInt32("UserId", FromForm.Register.UserId);
                return RedirectToAction("HomePage");
            }
            else
            {
                return LoginReg();
            }
        }

        [HttpPost("users/login")]
        public IActionResult Login(LoginRegWrapper FromForm)
        {
            if (ModelState.IsValid)
            {
                User ExistsInDb = DbContext.Users.FirstOrDefault(u => u.Email == FromForm.Login.Email);

                if (ExistsInDb == null)
                {
                    ModelState.AddModelError("Login.Emial", "Invalid Email/Password");
                    return LoginReg();
                }
                PasswordHasher<LoginUser> Hasher = new PasswordHasher<LoginUser>();
                PasswordVerificationResult Result = Hasher.VerifyHashedPassword(FromForm.Login, ExistsInDb.Password, FromForm.Login.Password);

                if (Result == 0)
                {
                    ModelState.AddModelError("Login.Email", "Invalid Email/Password");
                    return LoginReg();
                }
                HttpContext.Session.SetInt32("UserId", ExistsInDb.UserId);
                return RedirectToAction("Homepage");
            }
            else
            {
                return LoginReg();
            }
        }

        [HttpGet("logout")]
        public RedirectToActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginReg");
        }

        [HttpGet("homepage")]
        public IActionResult Homepage()
        {
            int? LoggedId = HttpContext.Session.GetInt32("UserId");
            if (LoggedId == null)
            {
                return RedirectToAction("LoginReg");
            };

            HomepageWrapper HMod = new HomepageWrapper()
            {
                AllMessages = DbContext.Messages
                    .Include(m => m.Poster)
                    .Include(m => m.ListOfComments)
                    .ThenInclude(c => c.User)
                    .Include(c => c.ListOfComments)
                    .ToList(),
                LoggedUser = DbContext.Users
                    .FirstOrDefault(u => u.UserId == (int)LoggedId),
            };
            return View("Homepage", HMod);
        }

        [HttpPost("homepage/message/post")]
        public IActionResult CreateMessage(HomepageWrapper FromForm)
        {
            int? LoggedId = HttpContext.Session.GetInt32("UserId");
            if (LoggedId == null)
            {
                return RedirectToAction("LoginReg");
            }

            FromForm.Message.UserId = (int)LoggedId;

            if (ModelState.IsValid)
            {
                DbContext.Add(FromForm.Message);
                DbContext.SaveChanges();
                return RedirectToAction("Homepage");
            }
            else
            {
                return Homepage();
            }
        }

        [HttpPost("homepage/comment/post")]
        public IActionResult CreateComment(int MessageId)
        {
            int? LoggedId = HttpContext.Session.GetInt32("UserId");
            if (LoggedId == null)
            {
                return RedirectToAction("LoginReg");
            }


            if (ModelState.IsValid)
            {
                // To Do: Get Comments To Show Up on HomePage Upon Submission
                DbContext.Add(comment);
                DbContext.SaveChanges();
                return RedirectToAction("Homepage");
            }
            else
            {
                return Homepage();
            }
        }
    }
}