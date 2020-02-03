using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.Exceptions
{
    public class ReceiptNotFoundException : Exception
    {
        public ReceiptNotFoundException(int id) : base($"Receipt {id} not found.")
        {
        }
    }
}
