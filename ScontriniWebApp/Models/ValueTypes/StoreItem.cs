using ScontriniWebApp.Models.Enums;
using System;

namespace ScontriniWebApp.Models.ValueTypes
{
    public class StoreItem : Money
    {
        public StoreItem() : this(Currency.EUR, 00.0m, "sconosciuto")
        {

        }
        public StoreItem(Currency currency, decimal amount, string name)
        {
            Currency = currency;
            Amount = amount;
            Name = name.ToUpper();
        }
        public string Name { get; set; }
    }
}
