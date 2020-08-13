using System;
using System.Linq;
using System.Collections.Generic;
using CRUDelicious.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext DbContext;

        public HomeController(MyContext context)
        {
            DbContext = context;
        }

        //for each route this controller is to handle:
        [HttpGet("")]     //Http Method and the route
        public IActionResult Index()
        {
            IndexWrapper WMod = new IndexWrapper();
            WMod.TableModel = DbContext.Users.ToList();
            return View("Index", WMod);
        }
        [HttpGet("user/{id}")]
        public IActionResult SingleUser(int? id)
        {
            User SingleDisplay = DbContext.Users
                .FirstOrDefault(i => i.UserId == id);

            if (SingleDisplay == null)
            {
                return RedirectToAction("Index");
            }
            return View("SingleUser", SingleDisplay);
        }

        [HttpPost("/user/update/{id}")]
        public IActionResult UpdateUser(int id, User Form)
        {
            // Intruder ToUpdate = _context.Intruders.FirstOrDefault(i => i.IntruderId == id);

            // ToUpdate.Name = Form.Name;
            // ToUpdate.Age = Form.Age;
            // ToUpdate.IsHigh = Form.IsHigh;
            // ToUpdate.CatchPhrase = Form.CatchPhrase;
            // ToUpdate.UpdatedAt = DateTime.Now;

            // _context.SaveChanges();

            // Alternative, prettier way to update without having to manually
            // call out 982374897289347 fields
            Form.UserId = id;
            DbContext.Update(Form);
            DbContext.Entry(Form).Property("CreatedAt").IsModified = false;
            DbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost("/user/create")]
        public IActionResult CreateUser(IndexWrapper Form)
        {
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

        [HttpGet("/user/delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            User ToDelete = DbContext.Users
                .FirstOrDefault(i => i.UserId == id);

            DbContext.Remove(ToDelete);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}