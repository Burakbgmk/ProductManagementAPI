using MediatR;
using ProductManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Queries.ProductImageFile.GetProductImages
{
    public class GetProductImagesQuerry : IRequest<ServiceResponse<List<GetProductImagesQuerryResponse>>>
    {
        public Guid Id { get; set; }

    }
}
