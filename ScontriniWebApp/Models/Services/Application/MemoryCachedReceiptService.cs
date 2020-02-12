using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using ScontriniWebApp.Models.Options;
using ScontriniWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.Services.Application
{
    public class MemoryCachedReceiptService : IChachedReceiptService
    {

        private readonly IOptionsMonitor<CacheOptions> optionsMonitor;
        private readonly IReceiptService receiptService;
        private readonly IMemoryCache memoryCache;

        public MemoryCachedReceiptService(IOptionsMonitor<CacheOptions> optionsMonitor, IReceiptService receiptService, IMemoryCache memoryCache)
        {
            this.optionsMonitor = optionsMonitor;
            this.receiptService = receiptService;
            this.memoryCache = memoryCache;
        }
        public Task<ReceiptDetailViewModel> GetReceiptAsync(int id)
        {
            return memoryCache.GetOrCreateAsync($"Receipt-{id}", cacheEntry =>
            {
                cacheEntry.SetSize(1);
                cacheEntry.SetAbsoluteExpiration(TimeSpan.FromSeconds(optionsMonitor.CurrentValue.ExpirationInSeconds));
                return receiptService.GetReceiptAsync(id);
            });
        }

       public Task<List<ReceiptViewModel>> GetReceiptsAsync(int page, List<string> paymentMethods, decimal minValue, decimal maxValue, DateTime startDate, DateTime endDate)
        {
            return memoryCache.GetOrCreateAsync($"Receipt-{page}-{paymentMethods.GetHashCode()}-{minValue}-{maxValue}-{startDate.ToString()}-{endDate.ToString()}", cacheEntry =>
            {
                cacheEntry.SetSize(1);
                cacheEntry.SetAbsoluteExpiration(TimeSpan.FromSeconds(optionsMonitor.CurrentValue.ExpirationInSeconds));
                return receiptService.GetReceiptsAsync(page, paymentMethods, minValue, maxValue, startDate, endDate);
            });
        }

        public SearchViewModel GetReceiptsBySearch(string query)
        {
            return memoryCache.GetOrCreate($"ReceiptsBySearch-{query}", cacheEntry =>
            {
                cacheEntry.SetSize(1);
                cacheEntry.SetAbsoluteExpiration(TimeSpan.FromSeconds(optionsMonitor.CurrentValue.ExpirationInSeconds));
                return receiptService.GetReceiptsBySearch(query);
            });
        }

        public decimal GetReceiptsMaxValue()
        {
            return memoryCache.GetOrCreate($"MaxValue", cacheEntry =>
            {
                cacheEntry.SetSize(1);
                cacheEntry.SetAbsoluteExpiration(TimeSpan.FromSeconds(optionsMonitor.CurrentValue.ExpirationInSeconds));
                return receiptService.GetReceiptsMaxValue();
            });
        }

        public List<string> GetReceiptsMethods()
        {
            return memoryCache.GetOrCreate($"Methods", cacheEntry =>
            {
                cacheEntry.SetSize(1);
                cacheEntry.SetAbsoluteExpiration(TimeSpan.FromSeconds(optionsMonitor.CurrentValue.ExpirationInSeconds));
                return receiptService.GetReceiptsMethods();
            });
        }

        public List<int> GetReceiptsYears()
        {
            return memoryCache.GetOrCreate($"Years", cacheEntry =>
            {
                cacheEntry.SetSize(1);
                cacheEntry.SetAbsoluteExpiration(TimeSpan.FromSeconds(optionsMonitor.CurrentValue.ExpirationInSeconds));
                return receiptService.GetReceiptsYears();
            });
        }
    }
}
