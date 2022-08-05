using AutoMapper;
using MediatR;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Wrappers;
using ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ServiceResponse<Guid>>
    {
        private readonly IProductWriteRepository writeRepository;
        private readonly IProductReadRepository readRepository;

        public UpdateProductCommandHandler(IProductWriteRepository writeRepository, IProductReadRepository readRepository)
        {
            this.writeRepository = writeRepository;
            this.readRepository = readRepository;
        }

        public async Task<ServiceResponse<Guid>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await readRepository.GetByIdAsync(request.Id);
            var updatedProduct = writeRepository.UpdateAsync(product);
            updatedProduct.Name = request.Name != default ? request.Name : product.Name;
            updatedProduct.Quantity = request.Quantity != default ? request.Quantity : product.Quantity;
            updatedProduct.Price = request.Value != default ? request.Value : product.Price;
            await writeRepository.CommitAsync();
            return ServiceResponse<Guid>.Success(updatedProduct.Id,200);

        }
    }
}
