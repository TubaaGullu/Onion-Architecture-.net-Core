using AutoMapper;
using MVC_Onion_Project.Application.DTO_s.AuthorDTO_s;
using MVC_Onion_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Application.Profiles
{
    public class AuthorProfile :Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorListDTO>();
            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorCreateDTO, Author>();
            CreateMap<AuthorCreateDTO, AuthorDTO>();
            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorEditDTO, Author>();
        }
    }
}
