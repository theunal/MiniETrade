using Application.RequestParameters;
using MediatR;

namespace Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<GetAllProductsQueryResponse>
    {
        public Pagination Pagination { get; set; }
    }
}
