using AutoMapper;
using MVC_Onion_Project.Application.DTO_s;
using MVC_Onion_Project.Domain.Entities;
using MVC_Onion_Project.Presentation.Models.CategoryVM_s;

namespace MVC_Onion_Project.Presentation.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryListDto, CategoryListVM>();
            CreateMap<CategoryDto, CategoryDetailVM>();
            CreateMap<CategoryCreateVM, CategoryCreateDTO>();
            CreateMap<CategoryDto, CategoryEditVM>();
            CreateMap<CategoryEditVM, CategoryEditDTO>();
            CreateMap<CategoryDto, CategoryEditVM>();
            CreateMap<CategoryDto, CategoryCreateVM>();
          
        }
    }
}
