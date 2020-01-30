using System;
using System.Collections.Generic;

namespace ScontriniWebApp.Models.Entities
{
    public partial class ETransMethod
    {
        public ETransMethod()
        {
            Receipts = new HashSet<EReceipt>();
        }

        public long IdTransMethod { get; set; }
        public string TransImagePath { get; set; }
        public string PaymentMethod { get; set; }

        public virtual ICollection<EReceipt> Receipts { get; set; }
    }
}
