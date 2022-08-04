using AutoMapper;
using MediatR;
using ProductManagement.Application.Dtos;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductQuerry : IRequest<ServiceResponse<List<ProductViewDto>>>
    {
        
    }
}
