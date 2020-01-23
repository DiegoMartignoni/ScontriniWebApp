using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.ValueTypes
{
    public class ReceiptTemplate
    {
        public ReceiptTemplate() : this("unknown","unknown")
        {

        }

        public ReceiptTemplate(string imagePath, string name)
        {
            ImagePath = imagePath;
            Name = name;
        }

        public string ImagePath { get; set; }

        public string Name { get; set; }
    }
}
