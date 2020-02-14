using ScontriniWebApp.Models.ViewModels.ComponentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.ViewModels
{
    public class ReceiptsViewModel
    {

        public ListReceiptsViewModel ListReceipts { get; set; }

        public SliderComponentsModel MinValueSlider { get; set; }

        public SliderComponentsModel MaxValueSlider { get; set; }

        public RadioComponentsModel YearRadio { get; set; }

        public RadioComponentsModel MonthRadio { get; set; }

        public CheckboxComponentsModel PaymentMethodsCheckbox { get; set; }

        public int CurrentPage { get; set; }
    }
}
