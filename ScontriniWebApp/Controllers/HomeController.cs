using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScontriniWebApp.Models;
using ScontriniWebApp.Models.ViewModels;
using ScontriniWebApp.Models.ViewModels.ComponentsModels;

namespace ScontriniWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[ResponseCache(CacheProfileName = "Home")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Dashboard";

            ViewBag.NewBreadcrumItem = new BreadcrumComponentsModel
            {
                ItemController = "home",
                ItemAction = "index",
                ItemTitle = ViewData["Title"].ToString()
            };

            return View();
        }

    }
}
