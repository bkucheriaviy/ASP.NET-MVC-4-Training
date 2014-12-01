using System.Data.Entity;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
