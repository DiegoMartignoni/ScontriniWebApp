using ScontriniWebApp.Models.Enums;
using ScontriniWebApp.Models.ValueTypes;
using System;
using System.Data;

namespace ScontriniWebApp.Models.ViewModels
{
    public class ReceiptDetailViewModel : ReceiptViewModel
    {
        public ReceiptTemplate ReceiptTemplate { get; set; }

        public string OrigImagePath { get; set; }

        public string ElabImagePath { get; set; }

        public static new ReceiptDetailViewModel FromDataRow(DataRow receiptRow)
        {
            var receiptDetailViewModel = new ReceiptDetailViewModel
            {
                TransactionMethod = new TransactionMethods
                {
                    ImagePath = Convert.ToString(receiptRow["transImagePath"]),
                    PaymentMethod = Convert.ToString(receiptRow["paymentMethod"])
                },
                Location = Convert.ToString(receiptRow["location"]),
                DateTime = Convert.ToDateTime(receiptRow["fullDate"]),
                Price = new Money
                {
                    Currency = Enum.Parse<Currency>(Convert.ToString(receiptRow["currency"])),
                    Amount = Convert.ToDecimal(receiptRow["amount"])
                },
                ReceiptTemplate = new ReceiptTemplate
                {
                    ImagePath = Convert.ToString(receiptRow["templateImagePath"]),
                    Name = Convert.ToString(receiptRow["name"])
                },
                OrigImagePath = Convert.ToString(receiptRow["origImagePath"]),
                ElabImagePath = Convert.ToString(receiptRow["elabImagePath"]),
            };

            return receiptDetailViewModel;
        }
    }
}
