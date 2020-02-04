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
            return memoryCache.GetOrCreateAsync($"Receipt{id}", cacheEntry =>
            {
                cacheEntry.SetAbsoluteExpiration(TimeSpan.FromSeconds(optionsMonitor.CurrentValue.Expiration));
                return receiptService.GetReceiptAsync(id);
            });
        }

        public Task<List<ReceiptViewModel>> GetReceiptsAsync()
        {
            return memoryCache.GetOrCreateAsync($"Receipt", cacheEntry =>
            {
                cacheEntry.SetAbsoluteExpiration(TimeSpan.FromSeconds(optionsMonitor.CurrentValue.Expiration));
                return receiptService.GetReceiptsAsync();
            });
        }
    }
}
