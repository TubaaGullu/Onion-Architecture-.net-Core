using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Onion_Project.Application.DTO_s;
using MVC_Onion_Project.Application.Services.CategoryService;
using MVC_Onion_Project.Domain.Entities;
using MVC_Onion_Project.Domain.Utilities.Concrete;
using MVC_Onion_Project.Presentation.Models.CategoryVM_s;


namespace MVC_Onion_Project.Presentation.Controllers
{
    public class CategoryController : BaseController
    {

        private readonly ICategoryService _categoryService;


        public CategoryController(ICategoryService categoryService, IMapper mapper, INotyfService notifyService) :base(notifyService, mapper)
        {
            _categoryService = categoryService;

        }


        // GET: CategoryController
        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.OrderByNameGetAllAsync();
            if (!result.IsSuccess)
            {
                ErrorNotification(result.Message);
                return View(_mapper.Map<List<CategoryListVM>>(result.Data));
            }
            var categoryList= _mapper.Map<List<CategoryListVM>>(result.Data);
            SuccessNotification(result.Message);

            return View(categoryList);
        }

        //GET: CategoryController/Details/5
     
        public async Task<IActionResult> Details(Guid id)
        {            
            var result = await _categoryService.GetByIdAsync(id);

            if (!result.IsSuccess)
            {
                ErrorNotification(result.Message);

                return View(_mapper.Map<CategoryDetailVM>(result.Data));
            }
            SuccessNotification(result.Message);

            var categoryDetailVm = _mapper.Map<CategoryDetailVM>(result.Data);
            return View(categoryDetailVm);

        }

        //GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateVM categoryCreateVM)
        {
            if (!ModelState.IsValid)
            { 
                return View(categoryCreateVM);
            }
            var categoryCreateDTO = _mapper.Map<CategoryCreateDTO>(categoryCreateVM);
            var result = await _categoryService.AddAsync(categoryCreateDTO);

            if (!result.IsSuccess)
            {
                ErrorNotification(result.Message);

                return View(_mapper.Map<CategoryCreateVM>(result.Data));

            }
            SuccessNotification(result.Message);

            var categoryCreatevm = _mapper.Map<CategoryCreateVM>(result.Data);

            return RedirectToAction(nameof(Index));

        }

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                ErrorNotification(result.Message);

                return View(_mapper.Map<CategoryEditVM>(result.Data));
            }
            var categoryEditVm = _mapper.Map<CategoryEditVM>(result.Data);
            return View(categoryEditVm);

        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CategoryEditVM categoryEditVM)
        {
            if (!ModelState.IsValid)
            {

                return View(categoryEditVM);
            }
            var categoryeditdto = _mapper.Map<CategoryEditDTO>(categoryEditVM);
            var result = await _categoryService.UpdateAsync(categoryeditdto);
            if (!result.IsSuccess)
            {
                ErrorNotification(result.Message);

                return RedirectToAction(nameof(Index));

			}
            SuccessNotification(result.Message);

            var resultVM = _mapper.Map<CategoryEditVM>(result.Data);
            return RedirectToAction(nameof(Index));

        }

        // GET: CategoryController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            
            var result = await _categoryService.DeleteAsync(id);
            if (!result.IsSuccess) 
            {
                ErrorNotification(result.Message);

                return RedirectToAction(nameof(Index));
			}
            //SuccessNotification(result.Message);

            return RedirectToAction(nameof(Index));
            
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<IActionResult> SortedCategories()
        {
         return View();
        }

    }
}
