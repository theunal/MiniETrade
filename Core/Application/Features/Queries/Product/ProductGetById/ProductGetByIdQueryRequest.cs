using MediatR;

namespace Application.Features.Queries.Product.ProductGetById
{
    public class ProductGetByIdQueryRequest : IRequest<ProductGetByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
