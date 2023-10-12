using MVC_Onion_Project.Application.DTO_s;
using MVC_Onion_Project.Domain.Core.Interfaces;
using MVC_Onion_Project.Domain.Entities;
using MVC_Onion_Project.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Application.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<IDataResult<List<CategoryListDto>>> GetAllAsync();
        Task<IDataResult<CategoryDto>> AddAsync(CategoryCreateDTO categoryCreateDTO);
        Task<IDataResult<CategoryDto>> GetByIdAsync(Guid id);
        Task<IDataResult<CategoryDto>> UpdateAsync(CategoryEditDTO categoryEditDTO);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<IEnumerable<CategoryListDto>>> OrderByNameGetAllAsync();
        Task<IDataResult<List<CategoryDto>>> GetByIdsAsync(List<Guid> ids);

    }
}
