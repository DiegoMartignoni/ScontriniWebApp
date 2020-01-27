using ScontriniWebApp.Models.Enums;
using System;
using System.Data;

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

        internal static StoreItem FromDataRow(DataRow storeItemsRow, string currency)
        {
            var item = new StoreItem
            {
                Currency = Enum.Parse<Currency>(currency),
                Amount = Convert.ToDecimal(storeItemsRow["amount"]),
                Name = Convert.ToString(storeItemsRow["name"])
            };

            return item;
        }
    }
}
