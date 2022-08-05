using MediatR;
using ProductManagement.Application.Dtos;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Commands.Category.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ServiceResponse<NoDataDto>>
    {
        private readonly ICategoryWriteRepository writeRepository;
        private readonly ICategoryReadRepository readRepository;

        public DeleteCategoryCommandHandler(ICategoryWriteRepository writeRepository, ICategoryReadRepository readRepository)
        {
            this.writeRepository = writeRepository;
            this.readRepository = readRepository;
        }
        public async Task<ServiceResponse<NoDataDto>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await readRepository.GetByIdAsync(request.Id);
            await writeRepository.DeleteAsync(category);
            await writeRepository.CommitAsync();
            return ServiceResponse<NoDataDto>.Success(204);
        }
    }
}
