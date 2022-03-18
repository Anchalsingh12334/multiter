
using BusinessLayer;
using CommonLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using multiter.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace multiter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private BLEmployeeBusiness business = new BLEmployeeBusiness();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var emp = business.GetEmployees();
            return View(emp);
        }
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            var result = business.CreateEmployee(employee);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("error", "Error in create employee");
                return View(employee);
            }

        }
    }
}

