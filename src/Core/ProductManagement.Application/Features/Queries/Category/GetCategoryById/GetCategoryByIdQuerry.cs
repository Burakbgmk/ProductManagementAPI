using MediatR;
using ProductManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Queries.Category.GetCategoryById
{
    public class GetCategoryByIdQuerry : IRequest<ServiceResponse<GetCategoryByIdViewModel>>
    {
        public Guid Id { get; set; }
    }
}
