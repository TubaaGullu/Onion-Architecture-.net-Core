using AutoMapper;
using MVC_Onion_Project.Application.DTO_s.BookDTO_s;
using MVC_Onion_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Application.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookListDTO>().ForMember(dest => dest.AuthorName, config => config.MapFrom(x => x.Author.Name + " " + x.Author.Surname));

            CreateMap<BookCreateDTO, Book>();
            CreateMap<Book, BookDTO>().ForMember(dest => dest.AuthorName, config => config.MapFrom(x => x.Author.Name + " " + x.Author.Surname));
            CreateMap<BookEditDTO, Book>();
        }
    }
}
