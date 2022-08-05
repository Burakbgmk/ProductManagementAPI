using MediatR;
using ProductManagement.Application.Dtos;
using ProductManagement.Application.Wrappers;

namespace ProductManagement.Application.Features.Queries.Category.GetAllCategories
{
    public class GetAllCategoryQuerry : IRequest<ServiceResponse<List<CategoryViewDto>>>
    {
    }
}
