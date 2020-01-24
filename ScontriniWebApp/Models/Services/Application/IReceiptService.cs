using ScontriniWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace ScontriniWebApp.Models.Services.Application
{
    public interface IReceiptService
    {
        List<ReceiptViewModel> GetReceipts();

        ReceiptDetailViewModel GetReceipt(int id);
    }
}
