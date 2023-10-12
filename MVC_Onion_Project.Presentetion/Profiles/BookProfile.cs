using AutoMapper;
using MVC_Onion_Project.Application.DTO_s.BookDTO_s;
using MVC_Onion_Project.Presentation.Models.BookVM_s;

namespace MVC_Onion_Project.Presentation.Profiles
{
    public class BookProfile :Profile
    {
        public BookProfile()
        {
            CreateMap<BookCreateVM, BookCreateDTO>();
            CreateMap<BookListDTO, BookListVM>();
            CreateMap<BookDTO, BookDetailVM>();
            CreateMap<BookDTO, BookEditVM>();
            CreateMap<BookEditVM, BookEditDTO>();
        }
    }
}
