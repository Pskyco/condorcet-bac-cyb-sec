using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataProtection.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DataProtection.Models;
using DataProtection.Persistence;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataProtection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dboContext;
        private readonly IConfiguration _configuration;
        private readonly IDataProtector _dataProtector;
        private readonly IDataProtector _dataProtectorTest;

        public HomeController(ApplicationDbContext dboContext,
            IDataProtectionProvider dataProtectionProvider,
            IConfiguration configuration)
        {
            _dboContext = dboContext;
            _configuration = configuration;
            _dataProtector = dataProtectionProvider.CreateProtector("HomeController");
            _dataProtectorTest = dataProtectionProvider.CreateProtector("HomeControllerTest");
        }

        public async Task<IActionResult> MyUserSecrets()
        {
            var myVar = _configuration.GetValue<string>("MySecretVar");
            return View((object)myVar);
        }

        public async Task<IActionResult> Index()
        {
            var persons = await _dboContext.Set<Person>().ToListAsync();
            var viewModels = new List<PersonViewModel>();

            foreach (var person in persons)
                viewModels.Add(person.ToViewModel(_dataProtector.Protect(person.Id.ToString())));

            // uncomment this to make it works
            // var myLimitedProtector = _dataProtector.ToTimeLimitedDataProtector();
            // var myLimitedString = myLimitedProtector.Protect("test", TimeSpan.FromSeconds(4));
            // var myUnprotectedString = myLimitedProtector.Unprotect(myLimitedString);
            // Thread.Sleep(5000); // sleep for 5 seconds
            // this line will throw an exception : lifetime has been reached.
            // myUnprotectedString = myLimitedProtector.Unprotect(myLimitedString);

            return View(viewModels);
        }

        public async Task<IActionResult> Details(string id)
        {
            // uncomment this to throw an exception : a var protected by data protector A can't be unprotected by a data protector B.
            // var unencryptedId = _dataProtectorTest.Unprotect(id);
            var unencryptedId = _dataProtector.Unprotect(id);

            var person = await _dboContext.Set<Person>().FindAsync(Guid.Parse(unencryptedId));

            if (person == null)
                throw new Exception($"Cannot find person with id '{id}'");

            return View(person.ToViewModel(""));
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