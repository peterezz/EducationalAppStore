using BusinessLogic.Mangers;
using DataAccessLayer.Models;
using edu_store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace edu_store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestManger manger;

        public HomeController(ILogger<HomeController> logger,TestManger manger)
        {
            _logger = logger;
            this.manger = manger;
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
        [HttpGet]
        public IActionResult test()
        {
            return View();
        }
        [HttpPost]
        public IActionResult test(CourseCategory category)
        {
            manger.addTest(category);
            return View();
        }
    }
}
