using Application.Repositories.ProductRepositories;
using MediatR;
namespace Application.Features.Commands.Product.ProductUpdate
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommandRequest, ProductUpdateCommandResponse>
    {
        private readonly IProductReadRepository productReadRepository;
        private readonly IProductWriteRepository productWriteRepository;
        public ProductUpdateCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            this.productReadRepository = productReadRepository;
            this.productWriteRepository = productWriteRepository;
        }

        public async Task<ProductUpdateCommandResponse> Handle(ProductUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await productReadRepository.GetByIdAsync(request.Id);
            product.ProductName = request.ProductName;
            product.Price = request.Price;
            product.Stock = request.Stock;
            productWriteRepository.Update(product);

            await productWriteRepository.SaveAsync();

            return new()
            {
                Message = "Ürün Güncellendi"
            };
        }
    }
}
