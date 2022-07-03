using Application.Repositories.ProductRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository productReadRepository;
        private readonly IProductWriteRepository productWriteRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            this.productWriteRepository = productWriteRepository;
            this.productReadRepository = productReadRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll(Guid id)
        {

            var product = await productReadRepository.GetByIdAsync(id);
            product.ProductName = "laptop 1";
            await productWriteRepository.SaveAsync();
         
            var result = productReadRepository.GetAll();
            return Ok(result);
        }



    }
}
