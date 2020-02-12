using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScontriniWebApp.Models.InputModels;
using ScontriniWebApp.Models.Services.Application;
using ScontriniWebApp.Models.ViewModels;
using ScontriniWebApp.Models.ViewModels.ViewComponents;

namespace ScontriniWebApp.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly IReceiptService receiptService;
        public static decimal ReceiptsPriceMaxValue { get; private set; }
        public static List<string> ReceiptsTransactionMethods { get; private set; }
        public static List<int> ReceiptsStoredYears { get; private set; }

        public ReceiptController(IChachedReceiptService receiptService)
        {
            this.receiptService = receiptService;
            ReceiptsPriceMaxValue = receiptService.GetReceiptsMaxValue();
            ReceiptsTransactionMethods = receiptService.GetReceiptsMethods();
            ReceiptsStoredYears = receiptService.GetReceiptsYears();
        }
        public IActionResult Index()
        {
            ViewData["ComingFrom1"] = "Dashboard";
            ViewData["Title"] = "Lista Scontrini";
            return View();
        }

        public async Task<IActionResult> List(ReceiptListInputModel model)
        {
            ViewData["ComingFrom1"] = "Dashboard";
            ViewData["Title"] = "Lista Scontrini";
            List<ReceiptViewModel> receipts = await receiptService.GetReceiptsAsync(model.Page, model.PaymentMethods, model.PriceMinValue, model.PriceMaxValue, model.StartDate, model.EndtDate);
            return View(new ReceiptsViewModel
            {
                Receipts = receipts,
                MinValueSlider = new SliderViewComponent
                {
                    SliderPosition = model.UserMinValue,
                    SliderMinValue = 0.00m,
                    SliderMaxValue = ReceiptsPriceMaxValue
                },
                MaxValueSlider = new SliderViewComponent
                {
                    SliderPosition = model.UserMaxValue,
                    SliderMaxValue = ReceiptsPriceMaxValue
                },
                YearRadio = new RadioViewComponent
                {
                    CurrentlyActive = model.Year,
                    RadioList = ReceiptsStoredYears
                },
                MonthRadio = new RadioViewComponent
                {
                    CurrentlyActive = model.Month
                },
                PaymentMethodsCheckbox = new CheckboxViewComponent
                {
                    PaymentMethodsChecked = model.PaymentMethods,
                    PaymentMethodsStored = ReceiptsTransactionMethods
                },
                FilterPaymentMethods = ReceiptsTransactionMethods,
                CurrentPage = model.Page
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