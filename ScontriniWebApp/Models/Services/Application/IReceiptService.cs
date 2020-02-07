using ScontriniWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.Services.Application
{
    public interface IReceiptService
    {
        Task<List<ReceiptViewModel>> GetReceiptsAsync();

        Task<ReceiptDetailViewModel> GetReceiptAsync(int id);

        SearchViewModel GetReceiptsBySearch(string query);
    }
}
