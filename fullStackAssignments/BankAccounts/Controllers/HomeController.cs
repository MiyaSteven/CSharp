using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BankAccounts.Models;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BankAccounts.Controllers
{

    public class HomeController : Controller
    {
        private MyContext DbContext;

        // public Random rand = new Random();
        // public string Generate()
        // {
        //     string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        //     string code = "";

        //     for (int i = 0; i < 14; i++)
        //     {
        //         code += chars[rand.Next(36)];
        //     }

        //     return code;
        // }

        // public void SessionInit()
        // {
        //     HttpContext.Session.SetString("Passcode", Generate());
        //     HttpContext.Session.SetInt32("Counter", 1);
        // }

        public HomeController(MyContext context)
        {
            DbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            IndexWrapper WMod = new IndexWrapper();
            WMod.TableModel = DbContext.RegUsers.ToList();

            return View("Index", WMod);
        }

        [HttpPost("/user/create")]
        public IActionResult RegisterUser(IndexWrapper Form)
        {
            // To Do:
            // add check confirm password === password before       registering
            if (ModelState.IsValid)
            {
                DbContext.Add(Form.FormModel);
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Index();
            }
        }

        [HttpGet("user/{id}")]
        public IActionResult SingleRegUser(int? id)
        {
            RegUser SingleDisplay = DbContext.RegUsers
                .FirstOrDefault(i => i.RegUserId == id);

            if (SingleDisplay == null)
            {
                return RedirectToAction("Index");
            }
            return View("SingleRegUser", SingleDisplay);
        }

        // [HttpGet("/user/update/{id}")]
        // public IActionResult UpdateRegUser(int id, IndexWrapper Form)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         DbContext.RegUsers
        //         .ToList()
        //         .Add(Form.FormModel);
        //         DbContext.SaveChanges();
        //         return RedirectToAction("UpdateRegUser");
        //     }
        //     else
        //     {
        //         return Index();
        //     }
        // }

        [HttpPost("/user/update/{id}")]
        public IActionResult UpdateRegUser(int id, IndexWrapper Form)
        {
            Form.FormModel.RegUserId = id;
            Console.WriteLine(id);
            DbContext.Update(Form.FormModel);
            DbContext.Entry(Form.FormModel).Property("CreatedAt").IsModified = false;
            DbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
