using AutoMapper;
using MediatR;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Wrappers;

namespace ProductManagement.Application.Features.Queries.GetProductById
{
    public class GetProductByIdQuerryHandler : IRequestHandler<GetProductByIdQuerry, ServiceResponse<GetProductByIdViewModel>>
    {
        private readonly IProductReadRepository productRepository;
        private readonly IMapper mapper;

        public GetProductByIdQuerryHandler(IProductReadRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<GetProductByIdViewModel>> Handle(GetProductByIdQuerry request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);
            if (product == null)
                return ServiceResponse<GetProductByIdViewModel>.Fail("Id is not found!", 404, true);
            var viewModel = mapper.Map<GetProductByIdViewModel>(product);
            return ServiceResponse<GetProductByIdViewModel>.Success(viewModel,200);
        }
    }
}
