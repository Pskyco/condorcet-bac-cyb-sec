using System.Diagnostics;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotyfService _notifyService;

        public HomeController(ILogger<HomeController> logger, INotyfService notifyService)
        {
            _logger = logger;
            _notifyService = notifyService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogError("I'm here");
            
            _notifyService.Success("This is a Success Notification");
            _notifyService.Error("This is an Error Notification");
            _notifyService.Warning("This is a Warning Notification");
            _notifyService.Information("This is an Information Notification");
            _notifyService.Success("This toast will be dismissed in 10 seconds.",10);
            _notifyService.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
            _notifyService.Custom("Custom Notification - closes in 5 seconds.", 10, "#135224", "fa fa-gear");

            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogError("I've got an error");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}