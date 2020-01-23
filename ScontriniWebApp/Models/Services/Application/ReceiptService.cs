using ScontriniWebApp.Models.ValueTypes;
using ScontriniWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace ScontriniWebApp.Models.Services.Application
{
    public class ReceiptService
    {
        public List<ReceiptViewModel> GetReceipts()
        {
            var receiptList = new List<ReceiptViewModel>();
            string[,] randomTransactionMethod = new string[2, 2];
            randomTransactionMethod[0, 0] = "credit-card-solid.svg";
            randomTransactionMethod[0, 1] = "Bancomat";
            randomTransactionMethod[1, 0] = "coins-solid.svg";
            randomTransactionMethod[1, 1] = "Contanti";

            var rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                var randomPrice = Convert.ToDecimal(rand.NextDouble() * 10 * 10);
                var ramdomMethodNumber = rand.Next(0, 2);
                var receipt = new ReceiptViewModel
                {
                    Id = i,
                    TransactionMethod = new TransactionMethods(randomTransactionMethod[ramdomMethodNumber, 0], randomTransactionMethod[ramdomMethodNumber, 1]),
                    Location = "Via S.Bernardino - BERGAMO",
                    DateTime = new DateTime(2020, 1, 22, 12, 34, 0),
                    Price = new Money(Enums.Currency.EUR, rand.NextDouble() > 0.5 ? randomPrice : randomPrice - 1)
                };
                receiptList.Add(receipt);
            }
            return receiptList;
        }
    }
}
