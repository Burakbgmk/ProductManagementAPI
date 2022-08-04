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
            var dto = mapper.Map<GetProductByIdViewModel>(product);
            return new ServiceResponse<GetProductByIdViewModel>(dto);
        }
    }
}
