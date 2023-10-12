using Microsoft.Extensions.DependencyInjection;
using MVC_Onion_Project.Application.Services.AuthorService;
using MVC_Onion_Project.Application.Services.BookService;
using MVC_Onion_Project.Application.Services.CategoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace MVC_Onion_Project.Application.Extension
{
    public static class DepedencyInjection 
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services) 
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            return services;
        }
    }
}
