using Application.Repositories.ProductRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.ProductRepositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(DataContext context) : base(context)
        {
        }
    }
}
