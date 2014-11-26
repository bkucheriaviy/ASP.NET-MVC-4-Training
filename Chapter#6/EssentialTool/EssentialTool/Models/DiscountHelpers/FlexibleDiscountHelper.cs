namespace EssentialTool.Models.DiscountHelpers
{
    public class FlexibleDiscountHelper:IDiscountHelper
    {
        public decimal ApplyDiscount(decimal totalCount)
        {
            var discount = totalCount > 100 ? 70 : 25;
            return totalCount - (discount/100m * totalCount);
        }
    }
}