using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVC_Onion_Project.Infrastructure.AppContext;
using MVC_Onion_Project.Infrastructure.Repositories.Concreates;
using MVC_Onion_Project.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MVC_Onion_Project.Infrastructure.Extension
{
    public static class Dependencyinjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => { options.UseLazyLoadingProxies();
                options.UseSqlServer(configuration.GetConnectionString("AppContextTest2"));
            });
            
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoriesBooksRepository, CategoriesBooksRepository>();
            return services;

        }
    }
}
