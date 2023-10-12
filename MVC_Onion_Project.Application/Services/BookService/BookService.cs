using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Onion_Project.Application.DTO_s.AuthorDTO_s;
using MVC_Onion_Project.Application.DTO_s.BookDTO_s;
using MVC_Onion_Project.Domain.Entities;
using MVC_Onion_Project.Domain.Utilities.Concrete;
using MVC_Onion_Project.Domain.Utilities.Interfaces;
using MVC_Onion_Project.Infrastructure.Repositories.Concreates;
using MVC_Onion_Project.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Application.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoriesBooksRepository _categoriesBooksRepository;

        public BookService(IBookRepository bookRepository, IMapper mapper, ICategoriesBooksRepository categoriesBooksRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _categoriesBooksRepository = categoriesBooksRepository;
        }

        private readonly IMapper _mapper;

        public async Task<IDataResult<BookDTO>> AddAsync(BookCreateDTO bookCreateDTO)
        {
            var book=_mapper.Map<Book>(bookCreateDTO);
            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveChangeAsync();

            await AddCategoriesToBookAsync(book.Id, bookCreateDTO.SelectedCategoryIds);
            return new SuccessDataResult<BookDTO>(_mapper.Map<BookDTO>(book), "başarılı");
        }

        public async Task<IDataResult<List<BookListDTO>>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            if (books.Count() <= 0)
            {
                return new ErrorDataResult<List<BookListDTO>>("sistemde kitap bulunamadı.");
            }
            return new SuccessDataResult<List<BookListDTO>>(_mapper.Map<List<BookListDTO>>(books), "kitap listeleme başarılı");
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book is null)
            {
              return new  ErrorResult("kitap bulunamadı.");
            }
			var removingCategories = await _categoriesBooksRepository.GetAllAsync(x => x.BookId == book.Id);
			await _categoriesBooksRepository.DeleteRangeAsync(removingCategories);
			await _categoriesBooksRepository.SaveChangeAsync();


			await _bookRepository.DeleteAsync(book);
           await _bookRepository.SaveChangeAsync();
            return new SuccessResult("kitap silindi");
        }

        public async Task<IDataResult<BookDTO>> GetByIdAsync(Guid id)
        {
            var book= await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return new ErrorDataResult<BookDTO>(" kitap bulunamadı.");
            }
            var bookDTO = _mapper.Map<BookDTO>(book);
			var categoryBooks = await _categoriesBooksRepository.GetAllAsync(x => x.BookId == book.Id);
			var categoryıds = categoryBooks.Select(x => x.CategoryId).ToList();
            bookDTO.SelectedCategoryIds = categoryıds;
            return new SuccessDataResult<BookDTO>(bookDTO, "kitap var.");
        }
        public async Task<IDataResult<BookDTO>> UpdateAsync(BookEditDTO bookEditDto)
        {
            var book = await _bookRepository.GetByIdAsync(bookEditDto.Id);
            if (book == null)
            {
                return new ErrorDataResult<BookDTO>("Kitap Bulunamadi");
            }
            var categories = await _bookRepository.GetAllAsync();
            var newCategories = categories.ToList();
            newCategories.Remove(book);
            var hasbook = newCategories.Any(x => x.Name == bookEditDto.Name);
            if (hasbook)
            {
                return new ErrorDataResult<BookDTO>("Kitap zaten kayitli");
            }
            var updateBook = _mapper.Map(bookEditDto, book);
            await _bookRepository.UpdateAsync(updateBook);
            await _bookRepository.SaveChangeAsync();
            await UpdateCategoriesToBookAsync(book.Id, bookEditDto.SelectedCategoryIds);

			return new SuccessDataResult<BookDTO>(_mapper.Map<BookDTO>(updateBook), "Kitap Guncelleme Basarili");
        }
        public async Task AddCategoriesToBookAsync(Guid bookId, List<Guid> categoryIds)
        {
            var categoryBooks = categoryIds.Select(categoryId => new CategoriesBooks
            {
                BookId = bookId,
                CategoryId = categoryId,
                
            }).ToList();

            await _categoriesBooksRepository.AddRangeAsync(categoryBooks);
            await _categoriesBooksRepository.SaveChangeAsync();
        }

		public async Task UpdateCategoriesToBookAsync(Guid bookId, List<Guid> selectedCategoryIds)
		{
			var existingCategories = await _categoriesBooksRepository.GetAllAsync(x => x.BookId == bookId);

			var existingCategoryIds = existingCategories.Select(c => c.CategoryId).ToList();
			var categoriesToRemove = existingCategories.Where(c => !selectedCategoryIds.Contains(c.CategoryId)).ToList();
			var categoriesToAdd = selectedCategoryIds.Where(id => !existingCategoryIds.Contains(id))
													 .Select(id => new CategoriesBooks { BookId = bookId, CategoryId = id })
													 .ToList();

			await _categoriesBooksRepository.DeleteRangeAsync(categoriesToRemove);

			await _categoriesBooksRepository.AddRangeAsync(categoriesToAdd);

			await _categoriesBooksRepository.SaveChangeAsync();
		}
        public async Task<List<string>> GetCategoryNamesByIdsAsync(List<Guid> categoryIds)
        {
            var categoryBooks = await _categoriesBooksRepository.GetAllAsync(categoryBook => categoryIds.Contains(categoryBook.CategoryId));
            var categoryNames = categoryBooks.Select(categoryBook => categoryBook.Category.Name).ToList();
            return categoryNames;
        }


    }
}
