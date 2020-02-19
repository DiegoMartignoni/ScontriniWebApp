using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScontriniWebApp.Models.InputModels;
using ScontriniWebApp.Models.Services.Application;
using ScontriniWebApp.Models.ViewModels;
using ScontriniWebApp.Models.ViewModels.ComponentsModels;

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
            ViewData["Title"] = "Nuovo scontrino";

            ViewBag.NewBreadcrumItem = new BreadcrumComponentsModel
            {
                ItemController = "receipt",
                ItemAction = "index",
                ItemTitle = ViewData["Title"].ToString()
            };

            return View();
        }

        public IActionResult List(ReceiptListInputModel model)
        {
            ViewData["Title"] = "Lista scontrini";

            ViewBag.NewBreadcrumItem = new BreadcrumComponentsModel
            {
                ItemController = "receipt",
                ItemAction = "list",
                ItemTitle = ViewData["Title"].ToString()
            };

            ListReceiptsViewModel receipts = receiptService.GetReceiptsAsync(model.Page, model.PaymentMethods, model.PriceMinValue, model.PriceMaxValue, model.StartDate, model.EndtDate);
            return View(new ReceiptsViewModel
            {
                ListReceipts = receipts,
                MinValueSlider = new SliderComponentsModel
                {
                    SliderPosition = model.UserMinValue,
                    SliderMinValue = 0.00m,
                    SliderMaxValue = ReceiptsPriceMaxValue
                },
                MaxValueSlider = new SliderComponentsModel
                {
                    SliderPosition = model.UserMaxValue,
                    SliderMaxValue = ReceiptsPriceMaxValue
                },
                YearRadio = new RadioComponentsModel
                {
                    CurrentlyActive = model.Year,
                    RadioList = ReceiptsStoredYears
                },
                MonthRadio = new RadioComponentsModel
                {
                    CurrentlyActive = model.Month
                },
                PaymentMethodsCheckbox = new CheckboxComponentsModel
                {
                    PaymentMethodsChecked = model.PaymentMethods,
                    PaymentMethodsStored = ReceiptsTransactionMethods
                },
                CurrentPage = model.Page
        });
        }

        public async Task<IActionResult> Detail(int id)
        {
            ViewData["Title"] = "Dettaglio scontrino";

            ViewBag.NewBreadcrumItem = new BreadcrumComponentsModel
            {
                ItemController = "receipt",
                ItemAction = "detail",
                ItemTitle = ViewData["Title"].ToString()
            };

            ReceiptDetailViewModel receipt = await receiptService.GetReceiptAsync(id);
            return View(receipt);
        }
    }
}