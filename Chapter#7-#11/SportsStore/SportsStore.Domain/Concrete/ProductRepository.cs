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

        public void SaveProduct(Product product)
        {
            using (var context = new ProductContext())
            {
                if (product.ProductId == 0)
                {
                    context.Products.Add(product);
                }
                else
                {
                    var productFromDb = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
                    if (productFromDb != null)
                    {
                        productFromDb.Name = product.Name;
                        productFromDb.Price = product.Price;
                        productFromDb.Description = product.Description;
                        productFromDb.Category = product.Category;
                        productFromDb.ImageData = product.ImageData;
                        productFromDb.ImageMimeType = product.ImageMimeType;
                    }
                }
                context.SaveChanges();
            }
        }

        public Product Delete(int productId)
        {
            using (var context = new ProductContext())
            {
                var product = context.Products.FirstOrDefault(p => p.ProductId == productId);
                if (product != null)
                    context.Products.Remove(product);
                context.SaveChanges();
                return product;
            }
        }
    }
}
