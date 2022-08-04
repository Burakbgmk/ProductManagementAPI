using MediatR;
using ProductManagement.Application.Dtos;
using ProductManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<ServiceResponse<NoDataDto>>
    {
        public Guid Id { get; set; }
    }
}
