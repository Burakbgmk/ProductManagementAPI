using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Features.Commands.CreateProduct;
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
        public async Task<IActionResult> Get()
        {
            var querry = new GetAllProductQuerry();
            return Ok(await mediator.Send(querry));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var querry = new GetProductByIdQuerry() { Id = id};
            return Ok(await mediator.Send(querry));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
