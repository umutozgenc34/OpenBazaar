using AutoMapper;
using OpenBazaar.Model.Categories.Dtos;
using OpenBazaar.Model.Categories.Entities;

namespace OpenBazaar.Service.Categories.Profiles;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<UpdateCategoryRequest, Category>();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
