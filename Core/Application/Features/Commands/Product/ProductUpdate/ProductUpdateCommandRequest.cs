using MediatR;

namespace Application.Features.Commands.Product.ProductUpdate
{
    public class ProductUpdateCommandRequest : IRequest<ProductUpdateCommandResponse>
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
    }
}
