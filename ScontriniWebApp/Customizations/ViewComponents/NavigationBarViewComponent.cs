﻿using Microsoft.AspNetCore.Mvc;
using ScontriniWebApp.Models.ViewModels;
using ScontriniWebApp.Models.ViewModels.ComponentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Customizations.ViewComponents
{
    public class NavigationBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(INavigationBar model)
        {
            if (!NavigationBarViewModel.RestoreNavTree(model))
            {
                NavigationBarViewModel.NavItems.Add(model);
            }
            return View();
        }
    }
}
