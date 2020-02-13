using ScontriniWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.Services.Application
{
    public interface IReceiptService
    {
        ListReceiptsViewModel GetReceiptsAsync(int page, List<string> paymentMethods, decimal minValue, decimal maxValue, DateTime startDate, DateTime endDate);

        Task<ReceiptDetailViewModel> GetReceiptAsync(int id);

        SearchViewModel GetReceiptsBySearch(string query);
        decimal GetReceiptsMaxValue();
        List<int> GetReceiptsYears();
        List<string> GetReceiptsMethods();
    }
}
