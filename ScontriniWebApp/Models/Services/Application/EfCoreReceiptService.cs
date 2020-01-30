﻿using Microsoft.EntityFrameworkCore;
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
        private readonly ScontriniWebAppDbContext dbContext;

        public EfCoreReceiptService(ScontriniWebAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<ReceiptDetailViewModel> GetReceiptAsync(int id)
        {
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
    }
}