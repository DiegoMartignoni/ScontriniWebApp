using Microsoft.AspNetCore.Mvc;
using ScontriniWebApp.Controllers;
using ScontriniWebApp.Customizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.InputModels
{
    [ModelBinder(BinderType = typeof(ReceiptListInputModelBinder))]
    public class ReceiptListInputModel
    {
        public ReceiptListInputModel(int page, List<string> paymentMethods, int minValue = 0, int maxValue = 5)
        {
            Page = Math.Max(1, page);
            if(paymentMethods.Any()) paymentMethods.Remove("empty"); else paymentMethods = ReceiptController.ReceiptsTransactionMethods;
            PaymentMethods = paymentMethods;
            PriceMinValue = (ReceiptController.ReceiptsPriceMaxValue * ((decimal)(minValue * 20) / 100));
            PriceMaxValue = PriceMinValue + ((ReceiptController.ReceiptsPriceMaxValue - maxValue) * ((decimal)(maxValue * 20) / 100));
        }

        public int Page { get; }

        public List<string> PaymentMethods { get; }

        public decimal PriceMinValue { get; }

        public decimal PriceMaxValue { get; }
    }
}
