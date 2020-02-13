using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.ViewModels.ViewComponents
{
    public class CheckboxViewComponent
    {
        public List<string> PaymentMethodsChecked { get; internal set; }
        public List<string> PaymentMethodsStored { get; internal set; }
    }
}
