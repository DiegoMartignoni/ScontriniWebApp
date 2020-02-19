using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScontriniWebApp.Models.Services.Application;
using ScontriniWebApp.Models.ViewModels;
using ScontriniWebApp.Models.ViewModels.ComponentsModels;

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
            GenericInputComponentsModel queryInput = new GenericInputComponentsModel
            {
                Type = "search",
                Name = "query",
                Value = query,
                Method = "get"
            };

            List<GenericInputComponentsModel> inputValues = new List<GenericInputComponentsModel>();
            inputValues.Add(queryInput);

            ViewData["Title"] = "Risultati Ricerca";

            ViewBag.NewBreadcrumItem = new BreadcrumComponentsModel
            {
                ItemController = "search",
                ItemAction = "index",
                ItemTitle = ViewData["Title"].ToString(),
                ItemInputValues = inputValues
            };



            SearchViewModel searchResult = receiptService.GetReceiptsBySearch(query);
            return View(searchResult);
        }
    }
}