using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ganss.XSS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Xss()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Xss(User user)
        {
            user.Username = new HtmlSanitizer().Sanitize(user.Username);
            return View(user);
        }

        public IActionResult UnsafeJs(int userId)
        {
            return View(new User { UserId = userId });
        }

        [HttpPost]
        public IActionResult UnsafeJs(User model)
        {
            return RedirectToAction("UnsafeJs", new { userId = model.UserId });
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}