using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Entities;
using WebApplication.Models;
using WebApplication.Persistence;

namespace WebApplication.Controllers
{
    public class PcrTestController : Controller
    {
        private readonly ILogger<PcrTestController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public PcrTestController(ILogger<PcrTestController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        // GET
        public IActionResult Index()
        {
            return View(_dbContext.PcrTests.ToList());
        }

        public IActionResult Create()
        {
            return RedirectToAction("Edit");
        }

        public IActionResult Edit(Guid id)
        {
            PcrTest pcrTest = null;

            if (id != Guid.Empty)
                pcrTest = _dbContext.PcrTests.Find(id);

            pcrTest ??= new PcrTest();
            
            return View(new PcrTestViewModel()
            {
                Code = pcrTest.Code,
                Comment = pcrTest.Comment,
                AnalysisDate = pcrTest.AnalysisDate,
                Id = pcrTest.Id,
            });
        }

        [HttpPost]
        public IActionResult Edit(PcrTestViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _logger.LogTrace($"Received model with code {model.Code}");

            PcrTest pcrTest = null;

            if (model.Id != Guid.Empty)
                pcrTest = _dbContext.PcrTests.Find(model.Id);

            pcrTest ??= new PcrTest();
            pcrTest.Code = model.Code;
            pcrTest.Comment = model.Comment;
            pcrTest.AnalysisDate = model.AnalysisDate;
            pcrTest.ReceptionDate = model.ReceptionDate;

            _dbContext.Update(pcrTest);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(Guid id)
        {
            PcrTest pcrTest = null;

            if (id != Guid.Empty)
                pcrTest = _dbContext.PcrTests.Find(id);

            if (pcrTest != null)
            {
                _dbContext.Remove(pcrTest);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}