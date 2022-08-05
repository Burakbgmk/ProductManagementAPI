using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Features.Commands.Category.CreateCategory;
using ProductManagement.Application.Features.Commands.Category.DeleteCategory;
using ProductManagement.Application.Features.Commands.Category.UpdateCategory;
using ProductManagement.Application.Features.Queries.Category.GetAllCategories;
using ProductManagement.Application.Features.Queries.Category.GetCategoryById;

namespace ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var querry = new GetAllCategoryQuerry();
            return Ok(await mediator.Send(querry));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCategoryByIdQuerry querry)
        {
            return Ok(await mediator.Send(querry));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
