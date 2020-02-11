using ScontriniWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.Services.Application
{
    public interface IReceiptService
    {
        Task<List<ReceiptViewModel>> GetReceiptsAsync(int page, List<string> paymentMethods, decimal minValue, decimal maxValue, int year, int month);

        Task<ReceiptDetailViewModel> GetReceiptAsync(int id);

        SearchViewModel GetReceiptsBySearch(string query);
        decimal GetReceiptsMaxValue();
        List<int> GetReceiptsYears();
        List<string> GetReceiptsMethods();
    }
}
