using MediatR;

namespace Application.Features.Commands.Product.ProductDelete
{
    public class ProductDeleteCommandRequest : IRequest<ProductDeleteCommandResponse>
    {
        public string Id { get; set; }
    }
}
