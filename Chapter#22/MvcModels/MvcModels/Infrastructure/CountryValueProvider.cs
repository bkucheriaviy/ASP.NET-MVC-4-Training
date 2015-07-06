using System;
using System.Globalization;
using System.Web.Mvc;

namespace MvcModels.Infrastructure
{
    public class CountryValueProvider:IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return prefix.ToLower().IndexOf("country", StringComparison.Ordinal) > -1;
        }

        public ValueProviderResult GetValue(string key)
        {
            if (!ContainsPrefix(key))
                return null;
            return new ValueProviderResult("USA", "USA", CultureInfo.InvariantCulture);
        }
    }
}
