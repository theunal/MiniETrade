namespace Application.Features.Queries.Product.GetAllProducts
{
    public class GetAllProductsQueryResponse 
    {
        public IQueryable<Domain.Entities.Product> Products { get; set; }
        public int TotalCount { get; set; }
    }
}
