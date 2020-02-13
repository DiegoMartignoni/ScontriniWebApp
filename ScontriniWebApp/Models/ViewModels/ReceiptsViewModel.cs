using ScontriniWebApp.Models.ViewModels.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.ViewModels
{
    public class ReceiptsViewModel
    {

        public ListReceiptsViewModel ListReceipts { get; set; }

        public SliderViewComponent MinValueSlider { get; set; }

        public SliderViewComponent MaxValueSlider { get; set; }

        public RadioViewComponent YearRadio { get; set; }

        public RadioViewComponent MonthRadio { get; set; }

        public CheckboxViewComponent PaymentMethodsCheckbox { get; set; }

        public int CurrentPage { get; set; }
    }
}
