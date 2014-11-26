using System.Collections.Generic;
using System.Linq;
using EssentialTool.Models.DiscountHelpers;

namespace EssentialTool.Models
{
    public class LinqValueCalculator : ILinqValueCalculator
    {
        private readonly IDiscountHelper _discountHelper;

        public LinqValueCalculator(IDiscountHelper discountHelper)
        {
            _discountHelper = discountHelper;
        }

        public decimal ValueProduct(IEnumerable<Product> products)
        {
            return _discountHelper.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}