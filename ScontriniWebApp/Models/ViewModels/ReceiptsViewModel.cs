using ScontriniWebApp.Models.ViewModels.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.ViewModels
{
    public class ReceiptsViewModel
    {

        public List<ReceiptViewModel> Receipts { get; set; }

        public SliderViewComponent MinValueSlider { get; set; }

        public SliderViewComponent MaxValueSlider { get; set; }

        public int SliderPosition { get; set; }

        public List<int> FilterYearsStored { get; set; }

        public List<string> FilterPaymentMethods { get; set; }

        public int CurrentPage { get; set; }
    }
}
