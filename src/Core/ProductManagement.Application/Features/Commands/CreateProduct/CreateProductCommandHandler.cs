using AutoMapper;
using MediatR;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Wrappers;

namespace ProductManagement.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ServiceResponse<Guid>>
    {
        private readonly IProductWriteRepository productRepository;
        private readonly IMapper mapper;

        public CreateProductCommandHandler(IProductWriteRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Domain.Entities.Product>(request);
            await productRepository.AddAsync(product);
            await productRepository.CommitAsync();

            return new ServiceResponse<Guid>(product.Id);
        }
    }
}
