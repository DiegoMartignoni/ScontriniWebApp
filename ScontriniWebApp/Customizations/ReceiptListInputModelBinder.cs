using Microsoft.AspNetCore.Mvc.ModelBinding;
using ScontriniWebApp.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScontriniWebApp.Customizations
{
    public class ReceiptListInputModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            int page = Convert.ToInt32(bindingContext.ValueProvider.GetValue("Page").FirstValue);
            List<string> paymentMethods = bindingContext.ValueProvider.GetValue("PaymentMethods").ToList();
            string minValue = bindingContext.ValueProvider.GetValue("MinValue").FirstValue;
            string maxValue = bindingContext.ValueProvider.GetValue("MaxValue").FirstValue;
            var inputModel = minValue != null && maxValue != null ? new ReceiptListInputModel(page, paymentMethods, Convert.ToInt32(minValue), Convert.ToInt32(maxValue)) : new ReceiptListInputModel(page, paymentMethods);
            
            bindingContext.Result = ModelBindingResult.Success(inputModel);

            return Task.CompletedTask;
        }
    }
}
