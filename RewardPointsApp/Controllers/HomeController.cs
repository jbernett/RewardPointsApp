using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RewardPointsApp.Models;
using RewardPointsApp.Repositories;
using RewardPointsApp.Services;
using RewardPointsApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RewardPointsApp.Controllers
{
    public class HomeController : Controller
    {
        private RewardPointsDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, RewardPointsDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            CustomerService customerService = new CustomerService(_context);
            var customers = customerService.GetAllCustomersWithInvoices();
            return View(customers);
        }

        public IActionResult CalculatedRewards(CustomerViewModel customer)
        {
            CustomerService customerService = new CustomerService(_context);
            customerService.GetPastThreeMonthCustomerRewards(customer);
            return View("DisplayCustomer",customer);
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
