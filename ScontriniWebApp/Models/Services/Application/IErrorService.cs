using ScontriniWebApp.Models.ViewModels;
using System;

namespace ScontriniWebApp.Models.Services.Application
{
    public interface IErrorService
    {
        ErrorViewModel GetError(Exception error);
    }
}
