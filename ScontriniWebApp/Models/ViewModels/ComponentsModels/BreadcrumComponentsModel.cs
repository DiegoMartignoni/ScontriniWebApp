using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.ViewModels.ComponentsModels
{
    public class BreadcrumComponentsModel : INavigationBar
    {

        public string ItemController { get; set; }

        public string ItemAction { get; set; }

        public string ItemTitle { get; set; }

        string INavigationBar.Controller => ItemController.First().ToString().ToUpper() + ItemController.Substring(1).ToLower();

        string INavigationBar.Action => ItemAction.First().ToString().ToUpper() + ItemAction.Substring(1).ToLower();

        string INavigationBar.Title => ItemTitle.First().ToString().ToUpper() + ItemTitle.Substring(1).ToLower();
    }
}
