using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Onion_Project.Application.DTO_s;
using MVC_Onion_Project.Application.DTO_s.AuthorDTO_s;
using MVC_Onion_Project.Application.Services.AuthorService;
using MVC_Onion_Project.Application.Services.CategoryService;
using MVC_Onion_Project.Presentation.Models.AuthorVM_s;
using MVC_Onion_Project.Presentation.Models.CategoryVM_s;

namespace MVC_Onion_Project.Presentation.Controllers
{
    public class AuthorController : BaseController
    {
        private readonly IAuthorService _authorService;


        public AuthorController(IAuthorService authorService, IMapper mapper, INotyfService notifyService) : base(notifyService, mapper)
        {
           _authorService = authorService;

        }

        // GET: AuthorController
        public async Task<IActionResult> Index()
        {
            var result = await _authorService.GetAllAsync();

            if (!result.IsSuccess)
            {
                ErrorNotification(result.Message);
                return View(_mapper.Map<List<AuthorListVM>>(result.Data));
            }
            var authorList = _mapper.Map<List<AuthorListVM>>(result.Data);
            SuccessNotification(result.Message);

            return View(authorList);
            
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _authorService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                ErrorNotification(result.Message);

                return View(_mapper.Map<AuthorDetailVM>(result.Data));
            }
            SuccessNotification(result.Message);

            var categoryDetailVm = _mapper.Map<AuthorDetailVM>(result.Data);
            return View(categoryDetailVm);
        }



        // GET: AuthorController/Create
        public ActionResult Create()
        {
            AuthorCreateVM authorCreateVm = new AuthorCreateVM()
            {
                DateofBirth = DateTime.Now
            };

            return View(authorCreateVm);
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuthorCreateVM authorCreateVM)
        {
            if (!ModelState.IsValid)
            {

                return View(authorCreateVM);
            }
            var authorCreateDTO = _mapper.Map<AuthorCreateDTO>(authorCreateVM);
            var result = await _authorService.AddAsync(authorCreateDTO);

            if (!result.IsSuccess)
            {
                ErrorNotification(result.Message);

                return View(_mapper.Map<AuthorCreateVM>(result.Data));

            }
            SuccessNotification(result.Message);

            var authorCreatevm = _mapper.Map<AuthorCreateVM>(result.Data);

            return RedirectToAction(nameof(Index));

        }



        // GET: AuthorController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var result = await _authorService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                ErrorNotification(result.Message);
                return RedirectToAction(nameof(Index));
            }

            return View(_mapper.Map<AuthorEditVM>(result.Data));
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AuthorEditVM authorUpdateVm)
        {
            if (!ModelState.IsValid)
            {
                return View(authorUpdateVm);
            }
            var result = await _authorService.UpdateAsync(_mapper.Map<AuthorEditDTO>(authorUpdateVm));
            if (!result.IsSuccess)
            {
                ErrorNotification(result.Message);
                return RedirectToAction(nameof(Index));
            }
            SuccessNotification(result.Message);
            return RedirectToAction(nameof(Index));
        }

        // GET: AuthorController/Delete/5
        public async Task <ActionResult> Delete(Guid id)
        {
            var result = await _authorService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                ErrorNotification(result.Message);
                return RedirectToAction(nameof(Index));
            }
            SuccessNotification(result.Message);
            return RedirectToAction(nameof(Index));
        }



       
    }
}
