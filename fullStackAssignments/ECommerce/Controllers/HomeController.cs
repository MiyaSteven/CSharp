using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult LogReg()
        {
            return View("LogReg");
        }

        [HttpPost("/register")]
        public IActionResult Register(User RegForm)
        {
            if (ModelState.IsValid)
            {
                // What steps do we need to take?

                // Step 1: Let's check to see if the email is already registered
                if (_context.Users.Any(u => u.Email == RegForm.Email))
                {
                    ModelState.AddModelError("Email", "A user with that email address already exists. If it is you, please try logging in.");
                    return LogReg();
                }

                // Step 2: We want to encrypt the password, since the user is not already
                // registered, and they would like to!
                PasswordHasher<User> hasher = new PasswordHasher<User>();

                RegForm.Password = hasher.HashPassword(RegForm, RegForm.Password);

                // Step 3: Now that we have encrypted the password, let's add
                // the user to our database!
                _context.Add(RegForm);
                _context.SaveChanges();

                // Step 4: Now that the user has been created, let's log them in by putting
                // their user id in session!
                HttpContext.Session.SetInt32("UserId", RegForm.UserId);

                // Step 5: Send them to the Products page
                return RedirectToAction("Products");
            }
            else
            {
                return LogReg();
            }
        }

        [HttpPost("/login")]
        public IActionResult Login(LogUser LogForm)
        {
            if (ModelState.IsValid)
            {
                // Step 1: Query for a user in the database with the email address entered in the login form
                User userInDb = _context.Users.FirstOrDefault(u => u.Email == LogForm.LogEmail);

                // Step 2: Make sure that user actually exists!
                if (userInDb == null)
                {
                    ModelState.AddModelError("LogEmail", "Invalid username/password.");
                    return LogReg();
                }

                // Step 3: Now that we know that user exists, let's compare passwords
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                var result = hasher.VerifyHashedPassword(userInDb, userInDb.Password, LogForm.LogPass);

                if (result == 0)
                {
                    // If we're in here, that's the wrong password. But don't tell them that!
                    ModelState.AddModelError("LogEmail", "Invalid username/password.");
                    return LogReg();
                }

                // Step 4: Now that we've verified that they are registered and provided
                // the right password, let's log them in!
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);

                // Step 5: Now let's send them to the Products page!
                return RedirectToAction("Products");
            }
            else
            {
                return LogReg();
            }
        }

        [HttpGet("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LogReg");
        }

        [HttpGet("/products")]
        public IActionResult Products()
        {
            int? uId = HttpContext.Session.GetInt32("UserId");
            if (uId == null)
            {
                return RedirectToAction("LogReg");
            }

            ProductsWrapper WMod = new ProductsWrapper
            {
                LoggedUser = _context.Users
                    .Include(u => u.Products)
                    .ThenInclude(s => s.Orders)
                    .ThenInclude(sn => sn.Customer)
                    .FirstOrDefault(u => u.UserId == uId),
                AllProducts = _context.Products
                    .Include(s => s.User)
                    .Include(s => s.Orders)
                    .ThenInclude(sn => sn.Customer)
                    .Where(s => s.UserId != uId)
                    .ToList(),
            };

            return View("Products", WMod);
        }

        [HttpGet("/products/new")]
        public IActionResult NewProduct()
        {
            int? uId = HttpContext.Session.GetInt32("UserId");
            if (uId == null)
            {
                return RedirectToAction("LogReg");
            }
            return View("NewProduct");
        }

        [HttpPost("/products/new")]
        public IActionResult CreateProduct(Product Form)
        {
            int? uId = HttpContext.Session.GetInt32("UserId");
            if (uId == null)
            {
                return RedirectToAction("LogReg");
            }

            if (_context.Products.Any(s => s.ProductName == Form.ProductName))
            {
                ModelState.AddModelError("ProductName", "A product with that title already exists.");
                return NewProduct();
            }

            Form.UserId = (int)uId;

            if (ModelState.IsValid)
            {
                _context.Add(Form);
                _context.SaveChanges();
                return RedirectToAction("Products");
            }
            return NewProduct();
        }

        [HttpGet("/products/{id}/edit")]
        public IActionResult EditProduct(int id)
        {
            int? uId = HttpContext.Session.GetInt32("UserId");
            if (uId == null)
            {
                return RedirectToAction("LogReg");
            }

            Product ToEdit = _context.Products.FirstOrDefault(s => s.ProductId == id);

            if (ToEdit.UserId != (int)uId)
            {
                return RedirectToAction("Products");
            }

            return View("EditProduct", ToEdit);
        }

        [HttpPost("/products/{id}/edit")]
        public IActionResult UpdateProduct(int id, Product Form)
        {
            int? uId = HttpContext.Session.GetInt32("UserId");
            if (uId == null)
            {
                return RedirectToAction("LogReg");
            }

            if (_context.Products.Any(s => s.ProductName == Form.ProductName && s.ProductId != id))
            {
                ModelState.AddModelError("ProductName", "A product with that title already exists.");
                return EditProduct(id);
            }

            Form.UserId = (int)uId;

            if (ModelState.IsValid)
            {
                Form.ProductId = id;
                _context.Update(Form);
                _context.Entry(Form).Property("CreatedAt").IsModified = false;
                _context.SaveChanges();

                return RedirectToAction("Products");
            }

            return EditProduct(id);
        }

        [HttpGet("/products/{id}")]
        public IActionResult OneProduct(int id)
        {
            int? uId = HttpContext.Session.GetInt32("UserId");
            if (uId == null)
            {
                return RedirectToAction("LogReg");
            }

            Product ToProduct = _context.Products
                .Include(s => s.Orders)
                .ThenInclude(sn => sn.Customer)
                .FirstOrDefault(s => s.ProductId == id);

            if (ToProduct == null)
            {
                return RedirectToAction("Products");
            }

            OneProductWrapper WMod = new OneProductWrapper
            {
                LoggedId = (int)uId,
                Product = ToProduct,
                AllCustomers = _context.Customers
                    .Include(n => n.Orders)
                    .Where(n => !n.Orders.Any(sn => sn.ProductId == id))
                    .ToList()
            };

            return View("OneProduct", WMod);
        }

        [HttpGet("/customers/new")]
        public IActionResult NewCustomer()
        {
            int? uId = HttpContext.Session.GetInt32("UserId");
            if (uId == null)
            {
                return RedirectToAction("LogReg");
            }
            return View("NewCustomer");
        }

        [HttpPost("/customers/new")]
        public IActionResult CreateCustomer(Customer Form)
        {
            int? uId = HttpContext.Session.GetInt32("UserId");
            if (uId == null)
            {
                return RedirectToAction("LogReg");
            }

            if (_context.Customers.Any(n => n.CustomerName == Form.CustomerName))
            {
                ModelState.AddModelError("Customer Name", "A customer with that name already exists.");
                return NewCustomer();
            }

            if (ModelState.IsValid)
            {
                _context.Add(Form);
                _context.SaveChanges();
                return RedirectToAction("Products");
            }
            return NewCustomer();
        }

        [HttpPost("/products/{id}/addcustomer")]
        public IActionResult AddOrder(int id, OneProductWrapper Form)
        {
            int? uId = HttpContext.Session.GetInt32("UserId");
            if (uId == null)
            {
                return RedirectToAction("LogReg");
            }

            if (!_context.Products.Any(s => s.ProductId == id))
            {
                return RedirectToAction("Products");
            }

            Form.AddOrderForm.ProductId = id;
            _context.Add(Form.AddOrderForm);
            _context.SaveChanges();

            return RedirectToAction("Products", new { id = id });
        }

        [HttpGet("/products/{id}/delete")]
        public IActionResult DeleteProduct(int id)
        {
            int? uId = HttpContext.Session.GetInt32("UserId");
            if (uId == null)
            {
                return RedirectToAction("LogReg");
            }

            Product ToDelete = _context.Products.FirstOrDefault(s => s.ProductId == id);

            if (ToDelete == null || ToDelete.UserId != (int)uId)
            {
                return RedirectToAction("Products");
            }

            _context.Remove(ToDelete);
            _context.SaveChanges();

            return RedirectToAction("Products");
        }
    }
}