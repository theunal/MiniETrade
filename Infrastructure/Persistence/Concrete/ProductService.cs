using Application.Abstract;
using Domain.Entities;

namespace Persistence.Concrete
{
    public class ProductService : IProductService // productdal
    {
        public List<Product> GetAll()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    ProductName = "Product 1",
                    Price = 100,
                    Stock = 35,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    ProductName = "Product 2",
                    Price = 200,
                    Stock = 1555,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    ProductName = "Product 3",
                    Price = 300,
                    Stock = 1345,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    ProductName = "Product 4",
                    Price = 400,
                    Stock = 1235,
                    CreatedDate = DateTime.Now
                }
            };
        }
    }
}
