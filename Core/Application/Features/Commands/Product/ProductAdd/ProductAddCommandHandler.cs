using Application.Repositories.ProductRepositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Product.ProductAdd
{
    public class ProductAddCommandHandler : IRequestHandler<ProductAddCommandRequest, ProductAddCommandResponse>
    {
        private readonly IProductWriteRepository productWriteRepository;

        public ProductAddCommandHandler(IProductWriteRepository productWriteRepository)
        {
            this.productWriteRepository = productWriteRepository;
        }

        public async Task<ProductAddCommandResponse> Handle(ProductAddCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product = new()
            {
                ProductName = request.ProductName,
                Price = request.Price,
                Stock = request.Stock
            };
            await productWriteRepository.AddAsync(product);
            await productWriteRepository.SaveAsync();

            return new()
            {
                Message = "Ürün Eklendi."
            };
        }
    }
}
