using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ScontriniWebApp.Models.Services.Application;
using ScontriniWebApp.Models.ViewModels;

namespace ScontriniWebApp.Controllers
{
    public class ErrorController : Controller
    {
        private readonly IErrorService errorService;

        public ErrorController(IErrorService errorService)
        {
            this.errorService = errorService;
        }
        public IActionResult Index()
        {
            IExceptionHandlerPathFeature feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ErrorViewModel error = errorService.GetError(feature.Error);
            return View(error);
        }
    }
}