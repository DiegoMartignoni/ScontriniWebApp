using System;
using System.Collections.Generic;

namespace ScontriniWebApp.Models.Entities
{
    public partial class EReceiptTemplate
    {
        public EReceiptTemplate()
        {
            Receipts = new HashSet<EReceipt>();
        }

        public int IdReceiptTemplate { get; set; }
        public string TemplateImagePath { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EReceipt> Receipts { get; set; }
    }
}
