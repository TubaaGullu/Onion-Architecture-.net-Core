using MVC_Onion_Project.Domain.Entities;
using MVC_Onion_Project.Infrastructure.AppContext;
using MVC_Onion_Project.Infrastructure.DataAccess.EntityFramework;
using MVC_Onion_Project.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Infrastructure.Repositories.Concreates
{
    public class CategoriesBooksRepository : BaseRepository<CategoriesBooks>, ICategoriesBooksRepository
    {
        public CategoriesBooksRepository(AppDbContext context) : base(context)
        {
            
        }

	}
}
