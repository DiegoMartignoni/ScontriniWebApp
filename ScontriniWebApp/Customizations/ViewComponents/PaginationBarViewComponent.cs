using Microsoft.AspNetCore.Mvc;
using ScontriniWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Customizations.ViewComponents
{
    public class PaginationBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ReceiptsViewModel model)
        {
            return View(model);
        }
    }
}
