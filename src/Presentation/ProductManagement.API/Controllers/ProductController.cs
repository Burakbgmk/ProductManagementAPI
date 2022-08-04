using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Features.Commands.CreateProduct;
using ProductManagement.Application.Features.Commands.DeleteProduct;
using ProductManagement.Application.Features.Commands.UpdateProduct;
using ProductManagement.Application.Features.Queries.GetAllProducts;
using ProductManagement.Application.Features.Queries.GetProductById;
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
        public async Task<IActionResult> GetAll()
        {
            var querry = new GetAllProductQuerry();
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
    }
}
