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

        public static bool RestoreNavTree(INavigationBar itemCheck)
        {
            for (int i = 0; i < NavItems.Count; i++)
            {
                if (NavItems[i].Controller.Equals(itemCheck.Controller) && NavItems[i].Action.Equals(itemCheck.Action) && NavItems[i].Title.Equals(itemCheck.Title))
                {
                    NavItems = NavItems.GetRange(0,i+1);
                    return true;
                }
            }
            return false;
        }
    }
}
