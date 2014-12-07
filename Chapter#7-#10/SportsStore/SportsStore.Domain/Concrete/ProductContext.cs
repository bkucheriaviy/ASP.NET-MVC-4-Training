using System.Data.Entity;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class ProductContext : DbContext
    {
        public ProductContext()
        {
            Database.SetInitializer<ProductContext>(null);
        }
        public DbSet<Product> Products { get; set; }
    }
}
