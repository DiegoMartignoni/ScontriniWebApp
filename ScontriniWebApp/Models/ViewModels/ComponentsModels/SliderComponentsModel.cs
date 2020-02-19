using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.ViewModels.ComponentsModels
{
    public class SliderComponentsModel
    {
        public int SliderPosition { get; internal set; }
        public decimal SliderMinValue { get; internal set; }
        public decimal SliderMaxValue { get; internal set; }
    }
}
