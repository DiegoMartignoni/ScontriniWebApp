using ScontriniWebApp.Models.Services.Infrastructure;
using ScontriniWebApp.Models.ValueTypes;
using ScontriniWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;

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
            string query = "SELECT R.idReceipt, T.transImagePath, T.paymentMethod, R.location, R.fullDate, R.currency, R.amount FROM RECEIPTS AS R INNER JOIN TRANS_METHODS AS T ON R.idTransactionMethod = T.idTransMethod";
            DataSet dataSet = db.Query(query);
            var dataTable = dataSet.Tables[0];
            var receiptList = new List<ReceiptViewModel>();

            foreach (DataRow receiptRow in dataTable.Rows)
            {
                List<StoreItem> storeItems = this.GetStoreItems(Convert.ToInt32(receiptRow["idReceipt"]), Convert.ToString(receiptRow["currency"]));
                ReceiptViewModel receipt = ReceiptViewModel.FromDataRow(receiptRow, storeItems);
                receiptList.Add(receipt);
            }

            return receiptList;
        }

        public List<StoreItem> GetStoreItems(int id, string currency)
        {
            string query = $"SELECT S.name, S.amount FROM STORE_ITEMS AS S WHERE S.idReceipt = {id}";
            DataSet dataSet = db.Query(query);
            var dataTable = dataSet.Tables[0];
            var storeItems = new List<StoreItem>();

            foreach (DataRow storeItemsRow in dataTable.Rows)
            {
                StoreItem item = StoreItem.FromDataRow(storeItemsRow, currency);
                storeItems.Add(item);
            }

            return storeItems;
        }
    }
}
