using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Dtos;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Queries.Category.GetAllCategories
{
    public class GetAllCategoryQuerryHandler : IRequestHandler<GetAllCategoryQuerry, ServiceResponse<List<CategoryViewDto>>>
    {
        private readonly ICategoryReadRepository categoryRepository;
        private readonly IMapper mapper;

        public GetAllCategoryQuerryHandler(ICategoryReadRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<List<CategoryViewDto>>> Handle(GetAllCategoryQuerry request, CancellationToken cancellationToken)
        {
            var categories = await categoryRepository.GetAll().Skip(request.Page * request.Size).Take(request.Size).ToListAsync();
            if (!categories.Any())
                return ServiceResponse<List<CategoryViewDto>>.Fail("No category is found!",404,true);
            var viewModel = mapper.Map<List<CategoryViewDto>>(categories);
            return ServiceResponse<List<CategoryViewDto>>.Success(viewModel,200);
        }
    }
}
