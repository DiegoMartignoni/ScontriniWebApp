using ScontriniWebApp.Models.ViewModels.ComponentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.ViewModels
{
    public static class NavigationBarViewModel
    {
        static NavigationBarViewModel()
        {
            NavItems = new List<INavigationBar>();
        }
        public static List<INavigationBar> NavItems { get; set; }
    }
}
