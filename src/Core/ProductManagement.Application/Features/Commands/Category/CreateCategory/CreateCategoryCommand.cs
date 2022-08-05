using MediatR;
using ProductManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommand : IRequest<ServiceResponse<Guid>>
    {
        public string Name { get; set; }
    }
}
