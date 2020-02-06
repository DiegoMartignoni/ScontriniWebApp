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

        public async Task<IActionResult> List()
        {
            ViewData["ComingFrom1"] = "Dashboard";
            ViewData["Title"] = "Lista Scontrini";
            List<ReceiptViewModel> receipts = await receiptService.GetReceiptsAsync();
            return View(receipts);
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