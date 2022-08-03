using AutoMapper;
using ProductManagement.Application.Features.Commands.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Domain.Entities.Product, Dtos.ProductViewDto>().ReverseMap();CreateMap<Domain.Entities.Product, CreateProductCommand>().ReverseMap();
        }
    }
}
