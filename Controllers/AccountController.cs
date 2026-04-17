using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.Data;
using TaskManagerApp.Models;

namespace TaskManagerApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public IActionResult Register(User user, string ConfirmPassword)
        {
            // Check if passwords match
            if (user.Password != ConfirmPassword)
            {
                ViewBag.Error = "Passwords do not match";
                return View(user);
            }

            // Save user to database
            _context.Users.Add(user);
            _context.SaveChanges();

            // Redirect after success
            return RedirectToAction("Index", "Home");
        }
    }
}