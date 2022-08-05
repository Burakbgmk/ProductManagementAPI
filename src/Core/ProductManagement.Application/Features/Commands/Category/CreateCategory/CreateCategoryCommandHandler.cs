using AutoMapper;
using MediatR;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ServiceResponse<Guid>>
    {
        private readonly ICategoryWriteRepository categoryRepository;
        private readonly IMapper mapper;

        public CreateCategoryCommandHandler(ICategoryWriteRepository writeRepository, IMapper mapper)
        {
            this.categoryRepository = writeRepository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Domain.Entities.Category>(request);
            await categoryRepository.AddAsync(category);
            var result = await categoryRepository.CommitAsync();
            return ServiceResponse<Guid>.Success(category.Id, 200);
        }
    }
}
