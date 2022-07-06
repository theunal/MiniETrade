using Application.Dtos;
using Application.Repositories.ProductRepositories;
using Application.RequestParameters;
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



        [HttpGet("getAll")]
        public IActionResult GetAll([FromQuery]Pagination pagination)
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
                Skip(pagination.Page * pagination.Size).Take(pagination.Size);

            var totalCount = productReadRepository.GetAll(false).Count();

            // hangi elemana sıçramak istiyorsak ona skip ediyoruz
            // sonra take ile alıyoruz

            return Ok(new
            {
                result,
                totalCount
            });
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await productReadRepository.GetByIdAsync(id, false);
            return Ok(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(ProductAddDto dto)
        {
            Product product = new Product
            {
                ProductName = dto.ProductName,
                Price = dto.Price,
                Stock = dto.Stock
            };
            await productWriteRepository.AddAsync(product);
            await productWriteRepository.SaveAsync();

            return Ok("ürün eklendi");
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ProductUpdateDto dto)
        {
            var product = await productReadRepository.GetByIdAsync(dto.Id);
            product.ProductName = dto.ProductName;
            product.Price = dto.Price;
            product.Stock = dto.Stock;
            productWriteRepository.Update(product);

            await productWriteRepository.SaveAsync(); 
            
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            await productWriteRepository.RemoveAsync(id);
            await productWriteRepository.SaveAsync();

            return Ok("Ürün silindi.");
        }


    }
}
