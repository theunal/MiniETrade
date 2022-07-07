using Application.Dtos;
using Application.Features.Queries.GetAllProducts;
using Application.Repositories.ProductRepositories;
using Application.RequestParameters;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IProductReadRepository productReadRepository;
        private readonly IProductWriteRepository productWriteRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductsController(IMediator mediator, IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.mediator = mediator;
            this.productReadRepository = productReadRepository;
            this.productWriteRepository = productWriteRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductsQueryRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
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


        [HttpPost("upload")]
        public async Task<IActionResult> Upload()
        {
            var uploadPath = Path.Combine(webHostEnvironment.WebRootPath, "resource/product-images");

            _ = !Directory.Exists(uploadPath) ? Directory.CreateDirectory(uploadPath) : null;

            Random random = new();
            foreach (var file in Request.Form.Files)
            {
                var fullPath = Path.
                   Combine(uploadPath, $"{random.NextDouble()}{Path.GetExtension(file.FileName)}");

                using FileStream fileStream =
                    new(fullPath, FileMode.Create, FileAccess.Write,
                    FileShare.None, 1024 * 1024, useAsync: false);

                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
            }
            return Ok();
        }

    }
}
