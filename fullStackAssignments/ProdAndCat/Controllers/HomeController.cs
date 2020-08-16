using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProdAndCat.Models;

namespace ProdAndCat.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Product> AllProducts = _context.Products
                .Include(a => a.ProdCategory)
                .Include(a => a.ProdAndCatAssoc)
                .ThenInclude(v => v.Category)
                .ToList();
            return View("Index", AllProducts);
        }

        [HttpGet("/products/create")]
        public IActionResult AddProduct(Product Form)
        {
            AssociationWrapper CMod = new AssociationWrapper();
            CMod.CategoryDropdown = _context.Categories.ToList();
            return View("AddProduct", Form);
        }

        [HttpPost("/products/create/success")]
        public IActionResult CreateProduct(AssociationWrapper Form)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Form.ToDisplay);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Index();
            }
        }

        [HttpGet("/products/{id}/edit")]
        public IActionResult EditProduct(int id)
        {
            Product ToEdit = _context.Products.FirstOrDefault(a => a.ProductId == id);
            return View("EditProduct", ToEdit);
        }

        [HttpGet("/products/{id}/addassociation")]
        public IActionResult AddAssociation(int id)
        {
            AssociationWrapper WMod = new AssociationWrapper();
            WMod.ToDisplay = _context.Products
                .Include(a => a.ProdAndCatAssoc)
                .FirstOrDefault(a => a.ProductId == id);

            WMod.CategoryDropdown = _context.Categories
                .Include(p => p.Associations)
                .Where(p => p.CategoryId != WMod.ToDisplay.ProdCategoryId && !p.Associations.Any(v => v.ProductId == WMod.ToDisplay.ProductId))
                .ToList();
            return View("AddAssociation", WMod);
        }

        [HttpPost("/products/{id}/addassociation")]
        public IActionResult CreateAssociation(int id, AssociationWrapper Form)
        {
            Form.AssociationForm.ProductId = id;
            _context.Add(Form.AssociationForm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}