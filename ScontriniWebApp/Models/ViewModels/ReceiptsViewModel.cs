using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.ViewModels
{
    public class ReceiptsViewModel
    {

        public List<ReceiptViewModel> Receipts { get; set; }

        public decimal MaxValue { get; set; }

        public List<int> Years { get; set; }

        public List<string> Methods { get; set; }
    }
}
