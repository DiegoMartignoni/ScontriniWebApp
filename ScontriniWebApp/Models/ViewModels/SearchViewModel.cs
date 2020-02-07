using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Models.ViewModels
{
    public class SearchViewModel
    {
        public string Query { get; set; }

        public int ResultCounter { get; set; }

        public Task<List<ReceiptViewModel>> LocationsFoundedAsync { get; set; }

        public Task<List<ReceiptViewModel>> ItemsFoundedAsync { get; set; }

        public Task<List<ReceiptViewModel>> TransMethodsFoundedAsync { get; set; }

        public string highlightResult(string result)
        {
            int startIndex = result.ToLower().IndexOf(Query.ToLower());
            string newString;
            if (startIndex < 0)
            {
                newString = result;
            } else
            {
                newString = "<span>" + result.Substring(0, startIndex) + "<span class='bg-warning'>" + result.Substring(startIndex, Query.Length) + "</span>" + result.Substring(startIndex + Query.Length) + "</span>";

            }
            return newString;
        }


    }
}
