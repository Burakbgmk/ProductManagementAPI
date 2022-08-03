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

namespace ProductManagement.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductQuerry : IRequest<ServiceResponse<List<ProductViewDto>>>
    {

        public class GetAllProductQuerryHandler : IRequestHandler<GetAllProductQuerry, ServiceResponse<List<ProductViewDto>>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;

            public GetAllProductQuerryHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }




            public async Task<ServiceResponse<List<ProductViewDto>>> Handle(GetAllProductQuerry request, CancellationToken cancellationToken)
            {
                var products = await productRepository.GetAllAsync();

                var viewModel = mapper.Map<List<ProductViewDto>>(products);

                

                return new ServiceResponse<List<ProductViewDto>>(viewModel);
            }
        }
    }
}
