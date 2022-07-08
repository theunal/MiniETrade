using Application.Features.Commands.Product.ProductAdd;
using Application.Features.Commands.Product.ProductDelete;
using Application.Features.Commands.Product.ProductUpdate;
using Application.Features.Queries.Product.GetAllProducts;
using Application.Features.Queries.Product.ProductGetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "admin")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductsQueryRequest id)
        {
            var result = await mediator.Send(id);
            return Ok(result);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById([FromQuery] ProductGetByIdQueryRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ProductAddCommandRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ProductUpdateCommandRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] ProductDeleteCommandRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }


        //[HttpPost("upload")]
        //public async Task<IActionResult> Upload()
        //{
        //    var uploadPath = Path.Combine(webHostEnvironment.WebRootPath, "resource/product-images");

        //    _ = !Directory.Exists(uploadPath) ? Directory.CreateDirectory(uploadPath) : null;

        //    Random random = new();
        //    foreach (var file in Request.Form.Files)
        //    {
        //        var fullPath = Path.
        //           Combine(uploadPath, $"{random.NextDouble()}{Path.GetExtension(file.FileName)}");

        //        using FileStream fileStream =
        //            new(fullPath, FileMode.Create, FileAccess.Write,
        //            FileShare.None, 1024 * 1024, useAsync: false);

        //        await file.CopyToAsync(fileStream);
        //        await fileStream.FlushAsync();
        //    }
        //    return Ok();
        //}

    }
}
