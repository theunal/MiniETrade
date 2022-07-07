using Domain.Entities;

namespace Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQueryResponse
    {
        public IQueryable<Product> Products { get; set; }
        public int TotalCount { get; set; }
    }
}
