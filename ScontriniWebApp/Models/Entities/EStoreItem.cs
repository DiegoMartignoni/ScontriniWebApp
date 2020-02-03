using ScontriniWebApp.Models.Enums;
using System;
using System.Collections.Generic;

namespace ScontriniWebApp.Models.Entities
{
    public partial class EStoreItem
    {
        public int IdStoreItem { get; set; }
        public int? IdReceipt { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }

        public virtual EReceipt IdReceiptNavigation { get; set; }
    }
}
