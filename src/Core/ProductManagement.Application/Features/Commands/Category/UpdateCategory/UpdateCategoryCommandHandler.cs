using AutoMapper;
using MediatR;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ServiceResponse<Guid>>
    {
        private readonly ICategoryWriteRepository writeRepository;
        private readonly ICategoryReadRepository readRepository;

        public UpdateCategoryCommandHandler(ICategoryWriteRepository writeRepository, ICategoryReadRepository readRepository)
        {
            this.writeRepository = writeRepository;
            this.readRepository = readRepository;
        }
        public async Task<ServiceResponse<Guid>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await readRepository.GetByIdAsync(request.Id);
            var updatedCategory = writeRepository.Update(category);
            updatedCategory.Name = request.Name != default ? request.Name : category.Name;
            await writeRepository.CommitAsync();
            return ServiceResponse<Guid>.Success(request.Id,200);
        }
    }
}
