using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.ViewModels.ViewComponents
{
    public class RadioViewComponent
    {
        public int CurrentlyActive { get; internal set; }
        public List<int> RadioList { get; internal set; }
    }
}
