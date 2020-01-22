using ScontriniWebApp.Models.ValueTypes;
using System;

namespace ScontriniWebApp.Models.ViewModels
{
    public class ReceiptViewModel
    {
        public int Id { get; set; }

        public TransactionMethods TransactionMethod { get; set; }

        public string Location { get; set; }

        public DateTime DateTime { get; set; }

        public Money Price { get; set; }
    }
}
