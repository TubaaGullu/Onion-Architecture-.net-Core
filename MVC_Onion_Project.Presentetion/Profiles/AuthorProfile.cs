using AutoMapper;
using MVC_Onion_Project.Application.DTO_s.AuthorDTO_s;
using MVC_Onion_Project.Presentation.Models.AuthorVM_s;

namespace MVC_Onion_Project.Presentation.Profiles
{
    public class AuthorProfile:Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorListDTO, AuthorListVM>().ForMember(dest=>dest.FullName, config=>config.MapFrom(x=> x.Name+ " "+ x.Surname)); //index list vm deki fullname"e list dto daki name ve surname in birleşimi yaptı.
            CreateMap<AuthorDTO, AuthorDetailVM>(); //detay
            CreateMap<AuthorCreateVM, AuthorCreateDTO>(); // create
            CreateMap<AuthorDTO, AuthorCreateVM>(); // create
            CreateMap<AuthorEditVM, AuthorEditDTO>();
            CreateMap<AuthorDTO, AuthorEditVM>();
        }
    }
}
