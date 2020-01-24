using ScontriniWebApp.Models.Services.Infrastructure;
using ScontriniWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace ScontriniWebApp.Models.Services.Application
{
    public class AdoNetReceiptService : IReceiptService
    {
        private readonly IDatabaseManager db;

        public AdoNetReceiptService(IDatabaseManager db)
        {
            this.db = db;
        }
        public ReceiptDetailViewModel GetReceipt(int id)
        {
            throw new NotImplementedException();
        }

        public List<ReceiptViewModel> GetReceipts()
        {
            string query = "SELECT * FROM RECEIPTS";
            db.Query(query);
            throw new NotImplementedException();
        }
    }
}
