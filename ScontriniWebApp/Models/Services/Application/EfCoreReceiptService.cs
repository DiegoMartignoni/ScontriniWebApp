using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScontriniWebApp.Models.Exceptions;
using ScontriniWebApp.Models.Services.Infrastructure;
using ScontriniWebApp.Models.ValueTypes;
using ScontriniWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.Services.Application
{
    public class EfCoreReceiptService : IReceiptService
    {
        private readonly ILogger<EfCoreReceiptService> logger;
        private readonly ScontriniWebAppDbContext dbContext;

        public EfCoreReceiptService(ILogger<EfCoreReceiptService> logger, ScontriniWebAppDbContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }
        public Task<ReceiptDetailViewModel> GetReceiptAsync(int id)
        {

            logger.LogInformation("Receipt {id} requested.", id);

            IQueryable<ReceiptDetailViewModel> query = dbContext.Receipts
                .Where(receiptDetail => receiptDetail.IdReceipt == id)
                .Select(receiptDetail => new ReceiptDetailViewModel
                {
                    Id = receiptDetail.IdReceipt,
                    TransactionMethod = dbContext.TransMethods
                    .Where(transactionMethod => transactionMethod.IdTransMethod == receiptDetail.IdTransactionMethod)
                    .Select(method => new TransactionMethods
                    {
                        ImagePath = method.TransImagePath,
                        PaymentMethod = method.PaymentMethod
                    }).Single(),
                    Location = receiptDetail.Location,
                    DateTime = Convert.ToDateTime(receiptDetail.FullDate),
                    Price = receiptDetail.Price,
                    ReceiptTemplate = dbContext.ReceiptTemplates
                        .Where(template => template.IdReceiptTemplate == receiptDetail.IdReceiptTemplate)
                        .Select(template => new ReceiptTemplate 
                        { 
                            ImagePath = template.TemplateImagePath,
                            Name = template.Name
                        }).Single(),
                    OrigImagePath = receiptDetail.OrigImagePath,
                    ElabImagePath = receiptDetail.ElabImagePath,
                    StoreItems = receiptDetail.StoreItems.Select(item => new StoreItem
                    {
                        Amount = item.Amount,
                        Currency = item.Currency,
                        Name = item.Name
                    }).ToList()
                });

            Task<ReceiptDetailViewModel> receipt = query.AsNoTracking().SingleAsync();

            if (receipt.IsFaulted)
            {
                logger.LogWarning("Receipt {id} not found.", id);
                
                throw new ReceiptNotFoundException(id);
            }

            return receipt;
        }

        public Task<List<ReceiptViewModel>> GetReceiptsAsync()
        {
            IQueryable<ReceiptViewModel> query = dbContext.Receipts.Select(receipt =>
            new ReceiptViewModel 
            { 
                Id = receipt.IdReceipt,
                TransactionMethod = dbContext.TransMethods
                    .Where(transactionMethod => transactionMethod.IdTransMethod == receipt.IdTransactionMethod)
                    .Select(method => new TransactionMethods
                    {
                        ImagePath = method.TransImagePath,
                        PaymentMethod = method.PaymentMethod
                    }).Single(),
                Location = receipt.Location,
                DateTime = Convert.ToDateTime(receipt.FullDate),
                Price = receipt.Price,
                StoreItems = receipt.StoreItems.Select(item => new StoreItem
                {
                    Amount = item.Amount,
                    Currency = item.Currency,
                    Name = item.Name
                }).ToList()

            });

            Task<List<ReceiptViewModel>> receipts = query.AsNoTracking().ToListAsync();
            
            return receipts;

        }

       public SearchViewModel GetReceiptsBySearch(string query)
        {
            IQueryable<ReceiptViewModel> locationFiledQuery = dbContext.Receipts
                            .Where(receipt => receipt.Location.ToLower().Contains(query.ToLower()))
                            .Select(receipt => new ReceiptViewModel
                            {
                                Id = receipt.IdReceipt,
                                TransactionMethod = dbContext.TransMethods
                                    .Where(transactionMethod => transactionMethod.IdTransMethod == receipt.IdTransactionMethod)
                                    .Select(method => new TransactionMethods
                                    {
                                        ImagePath = method.TransImagePath,
                                        PaymentMethod = method.PaymentMethod
                                    }).Single(),
                                Location = receipt.Location,
                                DateTime = Convert.ToDateTime(receipt.FullDate),
                                Price = receipt.Price,
                                StoreItems = receipt.StoreItems.Select(item => new StoreItem
                                {
                                    Amount = item.Amount,
                                    Currency = item.Currency,
                                    Name = item.Name
                                }).ToList()

                            });

            IQueryable<ReceiptViewModel> itemsFieldQuery = dbContext.Receipts
                            .Where(receipt => receipt.StoreItems
                                .Select(item => new StoreItem
                                {
                                    Name = item.Name
                                }).Single().Name.ToLower().Contains(query.ToLower()))
                            .Select(receipt => new ReceiptViewModel
                            {
                                Id = receipt.IdReceipt,
                                TransactionMethod = dbContext.TransMethods
                                    .Where(transactionMethod => transactionMethod.IdTransMethod == receipt.IdTransactionMethod)
                                    .Select(method => new TransactionMethods
                                    {
                                        ImagePath = method.TransImagePath,
                                        PaymentMethod = method.PaymentMethod
                                    }).Single(),
                                Location = receipt.Location,
                                DateTime = Convert.ToDateTime(receipt.FullDate),
                                Price = receipt.Price,
                                StoreItems = receipt.StoreItems
                                .Select(item => new StoreItem
                                {
                                    Amount = item.Amount,
                                    Currency = item.Currency,
                                    Name = item.Name
                                }).ToList()
                            });

            Task < List<ReceiptViewModel>> locationsSearched = locationFiledQuery.AsNoTracking().ToListAsync();
            Task<List<ReceiptViewModel>> itemsSearched = itemsFieldQuery.AsNoTracking().ToListAsync();
            SearchViewModel searchQuery = new SearchViewModel
            {
                Query = query,
                LocationsFoundedAsync = locationsSearched,
                ItemsFoundedAsync = itemsSearched,
                ResultCounter = locationFiledQuery.Count() + itemsFieldQuery.Count()
            };

            return searchQuery;
        }
    }
}
