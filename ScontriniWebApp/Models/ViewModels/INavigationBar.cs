using ScontriniWebApp.Models.ViewModels.ComponentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.ViewModels
{
    public interface INavigationBar
    {
        string Controller { get; }

        string Action { get; }

        string Title { get; }

        List<GenericInputComponentsModel> InputValues { get; }
    }
}
