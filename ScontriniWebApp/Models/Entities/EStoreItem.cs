using ScontriniWebApp.Models.ValueTypes;
using System;
using System.Collections.Generic;

namespace ScontriniWebApp.Models.Entities
{
    public partial class EStoreItem
    {
        public long IdStoreItem { get; set; }
        public long? IdReceipt { get; set; }
        public string Name { get; set; }
        public Money Price { get; set; }

        public virtual EReceipt IdReceiptNavigation { get; set; }
    }
}
