using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.ViewModels
{
    public class ListReceiptsViewModel
    {
        public List<ReceiptViewModel> Results { get; internal set; }
        public int TotalPages { get; internal set; }
    }
}
