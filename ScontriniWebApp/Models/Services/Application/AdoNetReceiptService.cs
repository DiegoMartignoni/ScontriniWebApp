//using ScontriniWebApp.Models.Services.Infrastructure;
//using ScontriniWebApp.Models.ValueTypes;
//using ScontriniWebApp.Models.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Threading.Tasks;

//namespace ScontriniWebApp.Models.Services.Application
//{
//    public class AdoNetReceiptService : IReceiptService
//    {
//        private readonly IDatabaseManager db;

//        public AdoNetReceiptService(IDatabaseManager db)
//        {
//            this.db = db;
//        }
//        public async Task<ReceiptDetailViewModel> GetReceiptAsync(int id)
//        {
//            FormattableString query = $"SELECT T.transImagePath, T.paymentMethod, R.location, R.fullDate, R.currency, R.amount, RT.name, R.origImagePath, R.elabImagePath, RT.templateImagePath FROM RECEIPTS AS R INNER JOIN TRANS_METHODS AS T ON R.idTransactionMethod = T.idTransMethod INNER JOIN RECEIPT_TEMPLATES AS RT ON R.idReceiptTemplate = RT.idReceiptTemplate WHERE R.idReceipt = {id}";
//            DataSet dataSet = await db.QueryAsync(query);
//            var dataTable = dataSet.Tables[0];
//            var receiptRow = dataTable.Rows[0];
//            List<StoreItem> storeItems = await this.GetStoreItemsAsync(id);

//            ReceiptDetailViewModel receipt = ReceiptDetailViewModel.FromDataRow(receiptRow);
//            receipt.StoreItems = storeItems;
//            return receipt;
//        }

//        public async Task<List<ReceiptViewModel>> GetReceiptsAsync()
//        {
//            FormattableString query = $"SELECT R.idReceipt, T.transImagePath, T.paymentMethod, R.location, R.fullDate, R.currency, R.amount FROM RECEIPTS AS R INNER JOIN TRANS_METHODS AS T ON R.idTransactionMethod = T.idTransMethod";
//            DataSet dataSet = await db.QueryAsync(query);
//            var dataTable = dataSet.Tables[0];
//            var receiptList = new List<ReceiptViewModel>();

//            foreach (DataRow receiptRow in dataTable.Rows)
//            {
//                List<StoreItem> storeItems = await this.GetStoreItemsAsync(Convert.ToInt32(receiptRow["idReceipt"]));
//                ReceiptViewModel receipt = ReceiptViewModel.FromDataRow(receiptRow);
//                receipt.StoreItems = storeItems;
//                receiptList.Add(receipt);
//            }

//            return receiptList;
//        }

//        private async Task<List<StoreItem>> GetStoreItemsAsync(int id)
//        {
//            FormattableString query = $"SELECT S.name, S.amount, S.currency FROM STORE_ITEMS AS S WHERE S.idReceipt = {id}";
//            DataSet dataSet = await db.QueryAsync(query);
//            var dataTable = dataSet.Tables[0];
//            var storeItems = new List<StoreItem>();

//            foreach (DataRow storeItemsRow in dataTable.Rows)
//            {
//                StoreItem item = StoreItem.FromDataRow(storeItemsRow);
//                storeItems.Add(item);
//            }

//            return storeItems;
//        }
//    }
//}
