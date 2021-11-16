using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    public class MessageController : Controller
    {
        private readonly ILogger<MessageController> _logger;

        public MessageController(ILogger<MessageController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public PartialViewResult GetMessageAlert(string message = "")
        {
            return PartialView("_Message", message ?? Guid.NewGuid().ToString());
        }
    }
}