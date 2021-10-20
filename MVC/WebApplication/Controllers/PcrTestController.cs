using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class PcrTestController : Controller
    {
        private readonly ILogger<PcrTestController> _logger;

        public PcrTestController(ILogger<PcrTestController> logger)
        {
            _logger = logger;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SavePcrTest(PcrTestViewModel model)
        {
            _logger.LogTrace($"Received model with code {model.Code}");
            return RedirectToAction("Index");
        }
    }
}