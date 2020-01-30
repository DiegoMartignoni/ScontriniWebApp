using ScontriniWebApp.Models.ValueTypes;
using System;
using System.Collections.Generic;

namespace ScontriniWebApp.Models.Entities
{
    public partial class EReceipt
    {
        public EReceipt()
        {
            StoreItems = new HashSet<EStoreItem>();
        }

        public long IdReceipt { get; set; }
        public long? IdTransactionMethod { get; set; }
        public long? IdReceiptTemplate { get; set; }
        public string Location { get; set; }
        public DateTime FullDate { get; set; }
        public Money Price { get; set; }
        public string OrigImagePath { get; set; }
        public string ElabImagePath { get; set; }

        public virtual EReceiptTemplate IdReceiptTemplateNavigation { get; set; }
        public virtual ETransMethod IdTransactionMethodNavigation { get; set; }
        public virtual ICollection<EStoreItem> StoreItems { get; set; }
    }
}
