using Application.Dtos;
using Application.Repositories.ProductRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        public IActionResult GetAll()
        {
            return Ok(productReadRepository.GetAll(false));
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
            await productWriteRepository.SaveAsync(); 
            
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            await productWriteRepository.RemoveAsync(id);
            await productWriteRepository.SaveAsync();

            return Ok();
        }


    }
}
