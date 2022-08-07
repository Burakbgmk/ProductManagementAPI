using MediatR;
using Microsoft.AspNetCore.Http;
using ProductManagement.Application.Dtos;
using ProductManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Commands.ProductImageFile.UploadProductImageFile
{
    public class UploadProductImageFileCommand : IRequest<ServiceResponse<NoDataDto>>
    {
        public Guid Id { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
