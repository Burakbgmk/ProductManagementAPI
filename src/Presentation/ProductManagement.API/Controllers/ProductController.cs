using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Features.Commands.CreateProduct;
using ProductManagement.Application.Features.Commands.DeleteProduct;
using ProductManagement.Application.Features.Commands.ProductImageFile.DeleteProductImageFile;
using ProductManagement.Application.Features.Commands.ProductImageFile.UploadProductImageFile;
using ProductManagement.Application.Features.Commands.UpdateProduct;
using ProductManagement.Application.Features.Queries.GetAllProducts;
using ProductManagement.Application.Features.Queries.GetProductById;
using ProductManagement.Application.Features.Queries.ProductImageFile.GetProductImages;
using ProductManagement.Application.Interfaces.Repositories;

namespace ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductQuerry querry)
        {
            return Ok(await mediator.Send(querry));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetProductByIdQuerry querry)
        {
            return Ok(await mediator.Send(querry));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductCommand command)
        {
            return Ok(await mediator.Send(command));
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery] UploadProductImageFileCommand command)
        {
            command.Files = Request.Form.Files;
            return Ok(await mediator.Send(command));
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProductImages([FromRoute] GetProductImagesQuerry request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] DeleteProductImageFileCommand command, [FromQuery] string imageId)
        {
            command.ImageId = imageId;
            return Ok(await mediator.Send(command));
        }

    }
}
