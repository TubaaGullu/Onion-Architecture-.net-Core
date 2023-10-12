using AutoMapper;
using MVC_Onion_Project.Application.DTO_s;
using MVC_Onion_Project.Domain.Core.Interfaces;
using MVC_Onion_Project.Domain.Entities;
using MVC_Onion_Project.Domain.Utilities.Concrete;
using MVC_Onion_Project.Domain.Utilities.Interfaces;
using MVC_Onion_Project.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MVC_Onion_Project.Application.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoriesBooksRepository _categoriesBooksRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper,  ICategoriesBooksRepository categoriesBooksRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoriesBooksRepository = categoriesBooksRepository;
        }

        public async Task<IDataResult<CategoryDto>> AddAsync(CategoryCreateDTO categoryCreateDTO)
        {
            var category= _mapper.Map<Category>(categoryCreateDTO);
            
            var varmi =await _categoryRepository.AnyAsync(x => x.Name.ToLower().Equals(category.Name.ToLower()));
            if (varmi) 
            {
               return new ErrorDataResult<CategoryDto>( "Kategori zaten var");
            }  
            var result = await _categoryRepository.AddAsync(category);
            
            await _categoryRepository.SaveChangeAsync();
            var cetegorycreatedto = _mapper.Map<CategoryDto>(category);
            return new SuccessDataResult<CategoryDto>(cetegorycreatedto, "Kategori eklendi");
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) 
            {
                return new ErrorResult("Sistemde kategori bulunamadı.");

            }
            else
            {
                var bookscategories = await _categoriesBooksRepository.GetAllAsync(x => x.CategoryId == id);
                if (bookscategories != null)
                {
                    var booknames = bookscategories.Select(x => x.Book.Name);
                    string bookNamesString = string.Join(", ", booknames);
                    return new ErrorResult($"Silmek istediğiniz kategori {bookNamesString} isimli kitaplarda kayıtlı. Öncelikle kitaplarda kategori kayıtlarını siliniz.");
                }
                await _categoryRepository.DeleteAsync(category);
                await _categoryRepository.SaveChangeAsync();
                return new SuccessResult( "Silme başarılı");

            }

        }

        public async Task<IDataResult<List<CategoryListDto>>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            if (categories.Count()<=0)
            {
                return new ErrorDataResult<List<CategoryListDto>>("Sistemde kategori bulunamadı.");
            }
            var categoriesListDto = _mapper.Map<List<CategoryListDto>>(categories);
            return new SuccessDataResult<List<CategoryListDto>>(categoriesListDto, "Listeleme başarılı");
        }

        public async Task<IDataResult<IEnumerable<CategoryListDto>>> OrderByNameGetAllAsync()
        {

            var shortcategories = await _categoryRepository.GetAllAsync(x=>x.Name, false, true);
            var categoriesListDto = _mapper.Map<IEnumerable<CategoryListDto>>(shortcategories);
            return new SuccessDataResult<IEnumerable<CategoryListDto>>(categoriesListDto, "Listeleme başarılı");
        }

        public async Task<IDataResult<CategoryDto>> GetByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);


            if (category == null)
            {
                return new ErrorDataResult<CategoryDto>("kategori bulunamadı.");

            }
            var categoryDTO = _mapper.Map<CategoryDto>(category);

            return new SuccessDataResult<CategoryDto>(categoryDTO, "Belirtilen kategori var.");

        }

        public async Task<IDataResult<CategoryDto>> UpdateAsync(CategoryEditDTO categoryEditDTO)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryEditDTO.Id);
            if (category == null)
            {
                return new ErrorDataResult<CategoryDto>("kategori bulunamadı.");

            }
            var categories = await _categoryRepository.GetAllAsync();
            var newCategories = categories.ToList();
            newCategories.Remove(category);
            var hasCategory = newCategories.Any(x => x.Name == categoryEditDTO.Name);
            if (hasCategory)
            {
                return new ErrorDataResult<CategoryDto>("Kategori zaten kayıtlı");
            }

            var updatedCategory = _mapper.Map(categoryEditDTO, category);
            await _categoryRepository.UpdateAsync(updatedCategory);
            await _categoryRepository.SaveChangeAsync();
            return new SuccessDataResult<CategoryDto>(_mapper.Map<CategoryDto>(updatedCategory), "Kategori güncelleme başarılı");

        }

        public async Task<IDataResult<List<CategoryDto>>> GetByIdsAsync(List<Guid> ids)
        {
            var categoryList = await _categoryRepository.GetByIdsAsync(ids);


            if (categoryList == null)
            {
                return new ErrorDataResult<List<CategoryDto>>("kategori bulunamadı.");

            }
            var categoryDTO = _mapper.Map<List<CategoryDto>>(categoryList);

            return new SuccessDataResult<List<CategoryDto>>(categoryDTO, "Belirtilen kategori var.");
        }
    }
}
