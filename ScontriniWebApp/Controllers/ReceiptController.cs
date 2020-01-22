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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            ReceiptService receiptService = new ReceiptService();
            List<ReceiptViewModel> receipts = receiptService.GetServices();
            return View(receipts);
        }

        public IActionResult Detail(int id)
        {
            ViewData["id"] = id;

            return View();
        }
    }
}