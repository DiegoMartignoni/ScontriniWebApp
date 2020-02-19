using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.ViewModels.ComponentsModels
{
    public interface IPaginationInfo
    {
        List<string> PaymentChecked { get; }

        int MinSliderPosition { get; }

        int MaxSliderPosition { get; }

        int YearActive { get; }

        int MonthActive { get; }

        int CurrentPage { get; }

        int TotalPages { get; }
    }
}
