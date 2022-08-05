using MediatR;
using ProductManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
