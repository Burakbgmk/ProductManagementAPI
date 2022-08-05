using AutoMapper;
using MediatR;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Queries.Category.GetCategoryById
{
    public class GetCategoryByIdQuerryHandler : IRequestHandler<GetCategoryByIdQuerry, ServiceResponse<GetCategoryByIdViewModel>>
    {
        private readonly ICategoryReadRepository categoryRepository;
        private readonly IMapper mapper;

        public GetCategoryByIdQuerryHandler(ICategoryReadRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<ServiceResponse<GetCategoryByIdViewModel>> Handle(GetCategoryByIdQuerry request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
                return ServiceResponse<GetCategoryByIdViewModel>.Fail("Id is not found",404,true);
            var viewModel = mapper.Map<GetCategoryByIdViewModel>(category);
            return ServiceResponse<GetCategoryByIdViewModel>.Success(viewModel,200);


        }
    }
}
