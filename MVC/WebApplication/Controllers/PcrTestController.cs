using System;
using System.Linq;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper _mapper;
        private readonly INotyfService _notifyService;

        public PcrTestController(ILogger<PcrTestController> logger, ApplicationDbContext dbContext, IMapper mapper, 
            INotyfService notifyService)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
            _notifyService = notifyService;
        }

        // GET
        public IActionResult Index()
        {
            // var viewModels = new List<PcrTestViewModel>();
            //
            // foreach (var pcrTest in _dbContext.PcrTests)
            //     viewModels.Add(_mapper.Map<PcrTestViewModel>(pcrTest));
            //
            // return View(viewModels);

            return View(_dbContext.PcrTests
                .Include(x => x.PerformerPerson)
                .Select(x => _mapper.Map<PcrTestViewModel>(x))
                .ToList());
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
            var viewModel = _mapper.Map<PcrTestViewModel>(pcrTest);
            viewModel.SliPersons = _dbContext.Persons
                                    .Select(x => new SelectListItem(x.FullName, x.Id.ToString()))
                                    .ToList();

            return View(viewModel);
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
            _mapper.Map(model, pcrTest);

            _dbContext.Update(pcrTest);
            _dbContext.SaveChanges();
            
            _notifyService.Success("Le test PCR a bien été sauvegardé");

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
                _notifyService.Success("Le test PCR a bien été supprimé");
            } else
                _notifyService.Warning("Aucun test PCR trouvé avec cet identifiant");

            return RedirectToAction("Index");
        }
    }
}