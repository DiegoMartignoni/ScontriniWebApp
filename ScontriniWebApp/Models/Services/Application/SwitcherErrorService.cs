using ScontriniWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.Services.Application
{
    public class SwitcherErrorService : IErrorService
    {
       public ErrorViewModel GetError(Exception error)
        {
            switch (error)
            {
                case InvalidOperationException _:
                    ErrorViewModel errorViewModel = new ErrorViewModel
                    {
                        Title = "Error - Not Found",
                        Description = "Siamo spiacenti, non è stato possibile trovare lo sacontrino da lei indicato",
                        StatusCode = 404
                    };
                    return errorViewModel;
                default:
                    errorViewModel = new ErrorViewModel
                    {
                        Title = "Error",
                        Description = "Siamo spiacenti, si è verificato un errore. Riprovare più tardi",
                        StatusCode = 500
                    };
                    return errorViewModel;
            }
        }
    }
}
