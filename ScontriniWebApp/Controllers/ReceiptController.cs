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
        private ReceiptService receiptService = new ReceiptService();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            List<ReceiptViewModel> receipts = receiptService.GetReceipts();
            return View(receipts);
        }

        public IActionResult Detail(int id)
        {
            ReceiptDetailViewModel receipt = receiptService.GetReceipt(id);
            return View(receipt);
        }
    }
}