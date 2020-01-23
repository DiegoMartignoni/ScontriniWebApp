using ScontriniWebApp.Models.ValueTypes;
using System;

namespace ScontriniWebApp.Models.ViewModels
{
    public class ReceiptDetailViewModel : ReceiptViewModel
    {
        public ReceiptTemplate ReceiptTemplate { get; set; }

        public string OrigImagePath { get; set; }

        public string ElabImagePath { get; set; }
    }
}
