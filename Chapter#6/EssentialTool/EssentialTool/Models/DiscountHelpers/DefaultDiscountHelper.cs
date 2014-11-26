namespace EssentialTool.Models.DiscountHelpers
{
    public class DefaultDiscountHelper : IDiscountHelper
    {
        public decimal DiscountSize { get; set; }
        public decimal ApplyDiscount(decimal totalCount)
        {
            return (totalCount - (DiscountSize / 100m * totalCount));
        }
    }
}