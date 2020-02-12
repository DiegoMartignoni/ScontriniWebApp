using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScontriniWebApp.Models.Services.Application;
using ScontriniWebApp.Models.ViewModels;

namespace ScontriniWebApp.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly IReceiptService receiptService;

        public ReceiptController(IChachedReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }
        public IActionResult Index()
        {
            ViewData["ComingFrom1"] = "Dashboard";
            ViewData["Title"] = "Lista Scontrini";
            return View();
        }

        public async Task<IActionResult> List(
            int page, 
            List<string> paymentMethods,
            int minValue = 0, 
            int maxValue = 5, 
            int year = -1, 
            int month = -1)
        {
#warning Attenzione: logica applicativa in un controller, eseguire un refactor in uno step a parte.
            ViewData["ComingFrom1"] = "Dashboard";
            ViewData["Title"] = "Lista Scontrini";
            decimal dbMaxValue = receiptService.GetReceiptsMaxValue();
            List<string> dbMethods = receiptService.GetReceiptsMethods(); 
            List<int> dbYears = receiptService.GetReceiptsYears();

            decimal minValueToPass = (dbMaxValue * ((decimal)(minValue * 20) / 100));
            decimal maxValueToPass = minValueToPass + ((dbMaxValue - minValueToPass) * ((decimal)(maxValue * 20) /100));

            if (paymentMethods.Any())
            {
                paymentMethods.Remove("empty");
            } else
            {
                paymentMethods = dbMethods;
            }

            DateTime startDate = new DateTime(1900, 1, 1);
            DateTime dateTime = DateTime.Now;

            List<ReceiptViewModel> receipts = await receiptService.GetReceiptsAsync(page, paymentMethods, minValueToPass, maxValueToPass, startDate, dateTime);
            

            return View(new ReceiptsViewModel
            {
                Receipts = receipts,
                MaxValue = dbMaxValue,
                Years = dbYears,
                Methods = dbMethods
            });
        }

        public async Task<IActionResult> Detail(int id)
        {
            ViewData["ComingFrom1"] = "Dashboard";
            ViewData["ComingFrom2"] = "Lista Scontrini";
            ViewData["Title"] = "Dettaglio Scontrino";
            ReceiptDetailViewModel receipt = await receiptService.GetReceiptAsync(id);
            return View(receipt);
        }
    }
}