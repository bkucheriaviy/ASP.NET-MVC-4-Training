using System.Collections.Generic;

namespace EssentialTool.Models
{
    public interface IShoppingCart
    {
        IEnumerable<Product> Products { get; set; }
        decimal CalculateProductTotal();
    }
}