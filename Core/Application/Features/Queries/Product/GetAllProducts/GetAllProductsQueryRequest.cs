using Application.RequestParameters;
using MediatR;

namespace Application.Features.Queries.Product.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<GetAllProductsQueryResponse>
    {
        public Pagination Pagination { get; set; }
    }
}
