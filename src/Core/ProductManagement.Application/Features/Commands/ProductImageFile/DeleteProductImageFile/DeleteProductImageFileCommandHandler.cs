using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Dtos;
using ProductManagement.Application.Interfaces.Repositories;
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

        public DeleteProductImageFileCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }


        public async Task<ServiceResponse<NoDataDto>> Handle(DeleteProductImageFileCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product? product = await _productReadRepository.dbSet.Include(p => p.ProductImageFiles)
                .FirstOrDefaultAsync(p => p.Id == request.Id);

            Domain.Entities.ProductImageFile? productImageFile = product?.ProductImageFiles.FirstOrDefault(p => p.Id == Guid.Parse(request.ImageId));

            if (productImageFile != null)
                product?.ProductImageFiles.Remove(productImageFile);

            await _productWriteRepository.CommitAsync();
            return ServiceResponse<NoDataDto>.Success(204);
        }
    }
}
