using System.Collections.Generic;

namespace EssentialTool.Models
{
    public interface ILinqValueCalculator
    {
        decimal ValueProduct(IEnumerable<Product> products);
    }
}