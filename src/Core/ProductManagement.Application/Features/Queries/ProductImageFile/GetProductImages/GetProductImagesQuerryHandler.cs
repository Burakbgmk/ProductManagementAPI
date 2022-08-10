using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Queries.ProductImageFile.GetProductImages
{
    public class GetProductImagesQuerryHandler : IRequestHandler<GetProductImagesQuerry, ServiceResponse<List<GetProductImagesQuerryResponse>>>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IConfiguration configuration;

        public GetProductImagesQuerryHandler(IProductReadRepository productReadRepository, IConfiguration configuration)
        {
            _productReadRepository = productReadRepository;
            this.configuration = configuration;
        }
        public async Task<ServiceResponse<List<GetProductImagesQuerryResponse>>> Handle(GetProductImagesQuerry request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product? product = await _productReadRepository.dbSet.Include(p => p.ProductImageFiles)
                   .FirstOrDefaultAsync(p => p.Id == request.Id);
            var result = product?.ProductImageFiles.Select(p => new GetProductImagesQuerryResponse
            {
                Path = $"{configuration["BaseStorageUrl"]}/{p.Path}",
                FileName = p.FileName,
                Id = p.Id
            }).ToList();

            return ServiceResponse<List<GetProductImagesQuerryResponse>>.Success(result, 200);
        }
    }
}
