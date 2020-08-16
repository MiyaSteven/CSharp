using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProductAndCategories.Models;

namespace ProductAndCategories.Controllers
{
    public class HomeController : Controller
    {
        private MyContext DbContext;

        public HomeController(MyContext context)
        {
            DbContext = context;
        }
        // Get Routes
        //
        [HttpGet("")]
        public IActionResult Index()
        {
            IndexWrapper WMod = new IndexWrapper();
            WMod.AllProducts = DbContext.Products
            .Include(a => a.CategoryAssociations)
            .ToList();
            WMod.AllCategories = DbContext.Categories
            .Include(c => c.ProductAssociations)
            .ToList();

            return View("Index", WMod);
        }

        [HttpGet("/products/create")]
        public IActionResult CreateProduct()
        {
            return View("CreateProduct");
        }

        [HttpGet("/categories/create")]
        public IActionResult CreateCategory()
        {
            return View("CreateCategory");
        }

        [HttpGet("/categories/all")]
        public IActionResult Categories()
        {
            IndexWrapper CMod = new IndexWrapper();
            CMod.AllCategories = DbContext.Categories.ToList();

            return View("Categories", CMod);
        }

        [HttpGet("/products/{id}")]
        public IActionResult SingleProduct(int? id)
        {
            Product SingleDisplay = DbContext.Products
            .FirstOrDefault(i => i.ProductId == id);

            if (SingleDisplay == null)
            {
                return RedirectToAction("Index");
            }
            return View("SingleProduct", SingleDisplay);
        }

        [HttpGet("/products/{id}/update")]
        public IActionResult UpdateProduct(int id)
        {
            Product ToUpdate = DbContext.Products.FirstOrDefault(p => p.ProductId == id);
            return View("UpdateProduct", ToUpdate);
        }

        [HttpPost("/products/create")]
        public IActionResult CreateProduct(Product FromForm)
        {
            if (ModelState.IsValid)
            {
                DbContext.Add(FromForm);
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return CreateProduct();
            }
        }

        [HttpPost("/categories/create/success")]
        public IActionResult CreateCategory(Category FromForm)
        {
            if (ModelState.IsValid)
            {
                DbContext.Add(FromForm);
                DbContext.SaveChanges();
                return RedirectToAction("Categories");
            }
            else
            {
                return Index();
            }
        }

        [HttpPost("/products/{id}/update/success")]
        public IActionResult UpdateProduct(int id, Product Form)
        {
            Form.ProductId = id;
            DbContext.Update(Form);
            DbContext.Entry(Form).Property("CreatedAt").IsModified = false;
            DbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost("/association/create")]
        public IActionResult CreateAssociation(IndexWrapper FromForm)
        {
            if (ModelState.IsValid)
            {
                if (DbContext.Associations.Any(h => h.ProductId == FromForm.Form.ProductId && h.CategoryId == FromForm.Form.CategoryId))
                {
                    ModelState.AddModelError("Product.ProductId", "Product Exists in that Category already");
                    return Index();
                }
                DbContext.Add(FromForm.Form);
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Index();
            }
        }
    }
}
