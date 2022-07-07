using MediatR;

namespace Application.Features.Commands.Product.ProductAdd
{
    public class ProductAddCommandRequest : IRequest<ProductAddCommandResponse>
    {
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
    }
}
