using System;

namespace EssentialTool.Models.DiscountHelpers
{
    public class MinimumDiscountHelper : IDiscountHelper
    {
        public decimal ApplyDiscount(decimal totalCount)
        {
            if (totalCount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (totalCount > 100)
            {
                return totalCount*0.9M;
            }
            if (totalCount >= 10 && totalCount <= 100)
            {
                return totalCount - 5;
            }
            return totalCount;
        }
    }
}