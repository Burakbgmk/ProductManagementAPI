using AutoMapper;
using ProductManagement.Application.Features.Commands.Category.CreateCategory;
using ProductManagement.Application.Features.Commands.CreateProduct;
using ProductManagement.Application.Features.Queries.Category.GetCategoryById;
using ProductManagement.Application.Features.Queries.GetProductById;

namespace ProductManagement.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Domain.Entities.Product, Dtos.ProductViewDto>().ReverseMap();
            CreateMap<Domain.Entities.Category, Dtos.CategoryViewDto>().ReverseMap();
            CreateMap<Domain.Entities.Product, CreateProductCommand>().ReverseMap();
            CreateMap<Domain.Entities.Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Domain.Entities.Product, GetProductByIdViewModel>().ReverseMap();
            CreateMap<Domain.Entities.Category, GetCategoryByIdViewModel>().ReverseMap();
        }
    }
}
