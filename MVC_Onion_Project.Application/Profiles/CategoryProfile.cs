using AutoMapper;
using MVC_Onion_Project.Application.DTO_s;
using MVC_Onion_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Application.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryListDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryEditDTO, Category>();
         

        }
    }
}
