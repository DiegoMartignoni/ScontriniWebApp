using ScontriniWebApp.Models.Enums;
using ScontriniWebApp.Models.ValueTypes;
using System;
using System.Collections.Generic;
using System.Data;

namespace ScontriniWebApp.Models.ViewModels
{
    public class ReceiptViewModel
    {
        public int Id { get; set; }

        public TransactionMethods TransactionMethod { get; set; }

        public string Location { get; set; }

        public DateTime DateTime { get; set; }

        public List<StoreItem> StoreItems { get; set; }

        public Money Price { get; set; }

        public static ReceiptViewModel FromDataRow(DataRow receiptRow, List<StoreItem> storeItems)
        {
            var receiptViewModel = new ReceiptViewModel
            {
                Id = Convert.ToInt32(receiptRow["idReceipt"]),
                TransactionMethod = new TransactionMethods
                {
                    ImagePath = Convert.ToString(receiptRow["transImagePath"]),
                    PaymentMethod = Convert.ToString(receiptRow["paymentMethod"])
                },
                Location = Convert.ToString(receiptRow["location"]),
                DateTime = Convert.ToDateTime(receiptRow["fullDate"]),
                StoreItems = storeItems,
                Price = new Money
                {
                    Currency = Enum.Parse<Currency>(Convert.ToString(receiptRow["currency"])),
                    Amount = Convert.ToDecimal(receiptRow["amount"])
                }
            };

            return receiptViewModel;
        }
    }
}
