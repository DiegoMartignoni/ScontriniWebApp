using ScontriniWebApp.Models.Enums;
using System;

namespace ScontriniWebApp.Models.ValueTypes
{
    public class Money
    {
        public Money() : this(Currency.EUR, 00.0m)
        {

        }

        public Money(Currency currency, decimal amount)
        {
            Amount = amount;
            Currency = currency;
        }

        public decimal Amount { get; set; }

        public Currency Currency { get; set; }

        public override string ToString()
        {
            return $"{Currency} {Amount:#.00}";
        }

    }
}