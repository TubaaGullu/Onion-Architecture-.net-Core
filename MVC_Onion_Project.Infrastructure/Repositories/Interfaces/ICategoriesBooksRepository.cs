using MVC_Onion_Project.Domain.Entities;
using MVC_Onion_Project.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Infrastructure.Repositories.Interfaces
{
    public interface ICategoriesBooksRepository :IAsyncInserttableRepository<CategoriesBooks>, IAsyncFindableRepository<CategoriesBooks>, IAsyncRepository, IAsyncQueryableRepository<CategoriesBooks>, IAsyncUpdatetableRepository<CategoriesBooks>, IAsyncDeletetableRepository<CategoriesBooks>, IAsyncOrderableRepository<CategoriesBooks>
    {
    }
}
