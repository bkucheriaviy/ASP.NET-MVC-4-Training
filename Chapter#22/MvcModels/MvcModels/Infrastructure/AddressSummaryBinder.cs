using System.Web.Mvc;
using MvcModels.Models;

namespace MvcModels.Infrastructure
{
    public class AddressSummaryBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = (AddressSummary) bindingContext.Model ?? new AddressSummary();
            model.City = GetValue(bindingContext, "City");
            model.Country = GetValue(bindingContext, "Country");
            return model;
        }

        private string GetValue(ModelBindingContext bindingContext, string name)
        {
            name = (bindingContext.ModelName == "" ? "" : bindingContext.ModelName + ".") + name;
            var result = bindingContext.ValueProvider.GetValue(name);
            if (result == null || result.AttemptedValue == "")

                return "Not specified";
            return result.AttemptedValue;
        }

    }
}
