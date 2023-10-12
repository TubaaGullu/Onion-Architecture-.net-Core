using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Onion_Project.Application.DTO_s.AuthorDTO_s;
using MVC_Onion_Project.Application.DTO_s.BookDTO_s;
using MVC_Onion_Project.Application.DTO_s.CategoriesBooksDTO_s;
using MVC_Onion_Project.Application.Services.AuthorService;
using MVC_Onion_Project.Application.Services.BookService;

using MVC_Onion_Project.Application.Services.CategoryService;
using MVC_Onion_Project.Domain.Utilities.Concrete;
using MVC_Onion_Project.Infrastructure.Repositories.Concreates;
using MVC_Onion_Project.Infrastructure.Repositories.Interfaces;
using MVC_Onion_Project.Presentation.Models.AuthorVM_s;
using MVC_Onion_Project.Presentation.Models.BookVM_s;
using MVC_Onion_Project.Presentation.Models.CategoriesBooksVM;
using NuGet.Packaging.Signing;
using System.Collections.Generic;

namespace MVC_Onion_Project.Presentation.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;


        public BookController(IBookService bookService, IAuthorService authorService, ICategoryService categoryService, IMapper mapper, INotyfService notifyService) : base(notifyService, mapper)
        {
            _bookService = bookService;
            _authorService = authorService;
            _categoryService = categoryService;

        }

        private readonly IAuthorService _authorService;

        public async Task<IActionResult> Index()
        {
           var result= await _bookService.GetAllAsync();

            SuccessNotification(result.Message);

            return View(_mapper.Map<List<BookListVM>>(result.Data));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _bookService.GetByIdAsync(id);
            var detailvm = _mapper.Map<BookDetailVM>(result.Data);
            detailvm.CategoryList = await GetCategoryNameSelectListAsync(result.Data.SelectedCategoryIds);
            if (!result.IsSuccess)
            {

                ErrorNotification(result.Message);

                return View(detailvm);
            }
            SuccessNotification(result.Message);

            return View(detailvm);

        }

        public async Task<IActionResult> Create()
        {

            BookCreateVM vm = new BookCreateVM()
            {
                AuthorList=await GetAuthorSelectListAsync(),
                CategoryList=await GetCategorySelectListAsync(),
            };


            return View(vm);

        }




        [HttpPost]
        public async Task<IActionResult> Create(BookCreateVM bookCreateVM)
        {
            if (!ModelState.IsValid)
            {
                return View(bookCreateVM);

            }
            var result = await _bookService.AddAsync(_mapper.Map<BookCreateDTO>(bookCreateVM));
            if (!result.IsSuccess)
            {
                ErrorNotification(result.Message);

            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {

            var result = await _bookService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                ErrorNotification(result.Message);
                return RedirectToAction(nameof(Index));
            }
            var bookeditvm = _mapper.Map<BookEditVM>(result.Data);

			bookeditvm.AuthorList = await GetAuthorSelectListAsync();
            bookeditvm.CategoryList = await GetCategorySelectListAsync();
            SuccessNotification(result.Message);

			return View(bookeditvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BookEditVM bookEditVM)
        {
            if (!ModelState.IsValid)
            {
                return View(bookEditVM);
            }
            var result = await _bookService.UpdateAsync(_mapper.Map<BookEditDTO>(bookEditVM));
            if (!result.IsSuccess)
            {
                ErrorNotification(result.Message);
                return RedirectToAction(nameof(Index));
            }
            SuccessNotification(result.Message);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _bookService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                ErrorNotification(result.Message);

                return RedirectToAction(nameof(Index));
            }
            SuccessNotification(result.Message);

            return RedirectToAction(nameof(Index));
        }


        private async Task<SelectList> GetAuthorSelectListAsync()
        {
            var authors = await _authorService.GetAllAsync();

            return new SelectList(authors.Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name + " " + x.Surname
            }), "Value", "Text");

        }
        private async Task<SelectList> GetCategorySelectListAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            return new SelectList(categories.Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name

            }), "Value", "Text");
        }
        private async Task<SelectList> GetCategoryNameSelectListAsync(List<Guid> ids)
        {
            var categories = await _categoryService.GetByIdsAsync(ids);
            return new SelectList(categories.Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name

            }), "Value", "Text");
        }



    }


}
