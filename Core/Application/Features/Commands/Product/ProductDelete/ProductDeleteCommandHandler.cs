using Application.Repositories.ProductRepositories;
using MediatR;

namespace Application.Features.Commands.Product.ProductDelete
{
    public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommandRequest, ProductDeleteCommandResponse>
    {
        private readonly IProductReadRepository productReadRepository;
        private readonly IProductWriteRepository productWriteRepository;
        public ProductDeleteCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            this.productReadRepository = productReadRepository;
            this.productWriteRepository = productWriteRepository;
        }

        public async Task<ProductDeleteCommandResponse> Handle(ProductDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            await productWriteRepository.RemoveAsync(request.Id);
            await productWriteRepository.SaveAsync();

            return new()
            {
                Message = "Ürün Silindi."
            };
        }
    }
}
