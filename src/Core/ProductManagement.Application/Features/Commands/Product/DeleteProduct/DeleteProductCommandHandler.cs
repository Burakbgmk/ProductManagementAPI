using AutoMapper;
using MediatR;
using ProductManagement.Application.Dtos;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ServiceResponse<NoDataDto>>
    {
        private readonly IProductWriteRepository writeRepository;
        private readonly IProductReadRepository readRepository;
        private readonly IMapper mapper;

        public DeleteProductCommandHandler(IProductWriteRepository writeRepository, IProductReadRepository readRepository, IMapper mapper)
        {
            this.writeRepository = writeRepository;
            this.readRepository = readRepository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<NoDataDto>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await readRepository.GetByIdAsync(request.Id);
            await writeRepository.DeleteAsync(product);
            await writeRepository.CommitAsync();

            return new ServiceResponse<NoDataDto>();
        }
    }
}
