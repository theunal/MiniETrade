using Application.Repositories.ProductRepositories;
using MediatR;

namespace Application.Features.Queries.Product.ProductGetById
{
    public class ProductGetByIdQueryHandler : IRequestHandler<ProductGetByIdQueryRequest, ProductGetByIdQueryResponse>
    {
        private readonly IProductReadRepository productReadRepository;

        public ProductGetByIdQueryHandler(IProductReadRepository productReadRepository)
        {
            this.productReadRepository = productReadRepository;
        }

        public async Task<ProductGetByIdQueryResponse> Handle(ProductGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            return new()
            {
                Product = await productReadRepository.GetByIdAsync(request.Id, false)
            };
        }
    }
}

