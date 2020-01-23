using System;

namespace ScontriniWebApp.Models.ValueTypes
{
    public class TransactionMethods
    {
        public TransactionMethods() : this("~/media/question-circle-solid.svg","Sconosciuto")
        {

        }

        public TransactionMethods(string imagePath, string paymentMethod)
        {
            ImagePath = imagePath;
            PaymentMethod = paymentMethod;
        }

        public string ImagePath { get; set; }
        public string PaymentMethod { get; set; }
    }
}