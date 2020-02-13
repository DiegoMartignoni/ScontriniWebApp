using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScontriniWebApp.Models.Services.Application;
using ScontriniWebApp.Models.ViewModels;

namespace ScontriniWebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly IReceiptService receiptService;

        public SearchController(IChachedReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }
        public IActionResult Index(string query)
        {
            ViewData["ComingFrom1"] = "Dashboard";
            ViewData["ComingFrom2"] = "Lista Scontrini";
            ViewData["Title"] = "Risultati Ricerca";


            SearchViewModel searchResult = receiptService.GetReceiptsBySearch(query);
            return View(searchResult);
        }
    }
}