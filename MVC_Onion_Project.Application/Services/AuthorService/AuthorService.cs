using AutoMapper;
using MVC_Onion_Project.Application.DTO_s;
using MVC_Onion_Project.Application.DTO_s.AuthorDTO_s;
using MVC_Onion_Project.Domain.Entities;
using MVC_Onion_Project.Domain.Utilities.Concrete;
using MVC_Onion_Project.Domain.Utilities.Interfaces;
using MVC_Onion_Project.Infrastructure.Repositories.Concreates;
using MVC_Onion_Project.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Application.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;


        public AuthorService(IAuthorRepository authorRepository, IMapper mapper, IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<IDataResult<AuthorDTO>> AddAsync(AuthorCreateDTO authorCreateDTO)
        {
            var authorFullName = authorCreateDTO.Name + " " + authorCreateDTO.Surname;
            var hasAuthor = await _authorRepository.AnyAsync(x => x.Name.ToLower() + " " + x.Surname.ToLower() == authorFullName.ToLower());
            if (hasAuthor)
            {
                return new ErrorDataResult<AuthorDTO>("Yazar zaten kayıtlı");
            }
            var author = _mapper.Map<Author>(authorCreateDTO);
            await _authorRepository.AddAsync(author);
            await _authorRepository.SaveChangeAsync();
            return new SuccessDataResult<AuthorDTO>(_mapper.Map< AuthorDTO>(author), "Yazar Eklendi");
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author is null)
            {
                return new ErrorResult("Yazar Bulunamadi");
            }
            var books = await _bookRepository.GetAllAsync(x => x.AuthorId == id);
            if (books != null)
            {
                var booknames = books.Select(x => x.Name);
                var booknamesstring = string.Join(",", booknames);
                return new ErrorResult($"Silmek istediğiniz yazarın {booknamesstring} isimlerinde kitapları kayıtlı, öncelikle kitap kayıtlarını siliniz.");
            }
            await _authorRepository.DeleteAsync(author);
            await _authorRepository.SaveChangeAsync();
            return new SuccessResult("Yazar Silme islemi Basarili");
        }

        public async Task<IDataResult<List<AuthorListDTO>>> GetAllAsync()
        {
            var authors= await _authorRepository.GetAllAsync();
            if (authors.Count() <= 0)
            {
                return new ErrorDataResult<List<AuthorListDTO>>("Sistemde yazar bulunamadı.");
            }
            var authorListDto = _mapper.Map<List<AuthorListDTO>>(authors);
            return new SuccessDataResult<List<AuthorListDTO>>(authorListDto, "Listeleme başarılı");
        }

        public async Task<IDataResult<AuthorDTO>> UpdateAsync(AuthorEditDTO authoreditDto)
        {
            var author = await _authorRepository.GetByIdAsync(authoreditDto.Id);
            if (author == null)
            {
                return new ErrorDataResult<AuthorDTO>("Yazar Bulunamadi");
            }
            var categories = await _authorRepository.GetAllAsync();
            var newCategories = categories.ToList();
            newCategories.Remove(author);
            var hasauthor = newCategories.Any(x => x.Name == authoreditDto.Name);
            if (hasauthor)
            {
                return new ErrorDataResult<AuthorDTO>("Yazar zaten kayitli");
            }
            var updateauthor = _mapper.Map(authoreditDto, author);
            await _authorRepository.UpdateAsync(updateauthor);
            await _authorRepository.SaveChangeAsync();
            return new SuccessDataResult<AuthorDTO>(_mapper.Map<AuthorDTO>(updateauthor), "Yazar Guncelleme Basarili");
        }

        async Task<IDataResult<AuthorDTO>> IAuthorService.GetByIdAsync(Guid id)
        {
            var author= await _authorRepository.GetByIdAsync(id);
            if (author == null)
            {
                return new ErrorDataResult<AuthorDTO>("Belirtilen ID ile yazar bulunamadı.");

            }
            var authorDTO = _mapper.Map<AuthorDTO>(author);

            return new SuccessDataResult<AuthorDTO>(authorDTO, "Belirtilen ID'de yazar var.");
        }


    }
}
