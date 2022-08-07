using MediatR;
using ProductManagement.Application.Dtos;
using ProductManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Commands.ProductImageFile.DeleteProductImageFile
{
    public class DeleteProductImageFileCommand : IRequest<ServiceResponse<NoDataDto>>
    {
        public Guid Id { get; set; }
        public string? ImageId { get; set; }
    }
}
