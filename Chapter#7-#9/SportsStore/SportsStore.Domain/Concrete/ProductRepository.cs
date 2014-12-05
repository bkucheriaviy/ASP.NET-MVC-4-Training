using System.Collections.Generic;
using System.Linq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> Products
        {
            get
            {
                using (var context = new ProductContext())
                {
                    return context.Products.ToList();
                }
            }
        }
    }
}
