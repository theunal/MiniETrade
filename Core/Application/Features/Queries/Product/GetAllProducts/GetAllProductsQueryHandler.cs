using Application.Repositories.ProductRepositories;
using MediatR;

namespace Application.Features.Queries.Product.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
    {
        private readonly IProductReadRepository productReadRepository;
        private readonly IProductWriteRepository productWriteRepository;

        public GetAllProductsQueryHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            this.productReadRepository = productReadRepository;
            this.productWriteRepository = productWriteRepository;
        }

        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            //return Ok(productReadRepository.GetAll(false).Select(x => new
            //{
            //    x.Id,
            //    x.ProductName,
            //    x.Stock,
            //    x.Price,
            //    x.CreatedDate,
            //    x.UpdatedDate
            //}));

            var result = productReadRepository.GetAll(false).
                            Skip(request.Pagination.Page * request.Pagination.Size).Take(request.Pagination.Size);

            var totalCount = productReadRepository.GetAll(false).Count();


            // hangi elemana sıçramak istiyorsak ona skip ediyoruz
            // sonra take ile alıyoruz

            return new()
            {
                Products = result,
                TotalCount = totalCount
            };
        }
    }
}
