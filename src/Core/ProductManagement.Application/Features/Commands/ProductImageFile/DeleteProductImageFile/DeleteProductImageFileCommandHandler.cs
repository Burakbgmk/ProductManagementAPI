using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductManagement.Application.Dtos;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Interfaces.Storage;
using ProductManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Commands.ProductImageFile.DeleteProductImageFile
{
    public class DeleteProductImageFileCommandHandler : IRequestHandler<DeleteProductImageFileCommand, ServiceResponse<NoDataDto>>
    {

        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        private readonly IStorageService storageService;
        private readonly IConfiguration configuration;

        public DeleteProductImageFileCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IStorageService storageService, IConfiguration configuration)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            this.storageService = storageService;
            this.configuration = configuration;
        }


        public async Task<ServiceResponse<NoDataDto>> Handle(DeleteProductImageFileCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product? product = await _productReadRepository.dbSet.Include(p => p.ProductImageFiles)
                .FirstOrDefaultAsync(p => p.Id == request.Id);

            Domain.Entities.ProductImageFile? productImageFile = product?.ProductImageFiles.FirstOrDefault(p => p.Id == Guid.Parse(request.ImageId));

            if (productImageFile != null)
            {
                product?.ProductImageFiles.Remove(productImageFile);
                await storageService.DeleteAsync(configuration["BaseStorageUrl"], productImageFile.Path);
            }

            await _productWriteRepository.CommitAsync();
            return ServiceResponse<NoDataDto>.Success(204);
        }
    }
}
