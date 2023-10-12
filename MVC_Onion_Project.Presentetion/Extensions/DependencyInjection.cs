using AspNetCoreHero.ToastNotification;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MVC_Onion_Project.Infrastructure.AppContext;
using System.Configuration;
using System.Reflection;


namespace MVC_Onion_Project.Presentation.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationService(this IServiceCollection services) 
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddControllersWithViews(opt => opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);// update ya da create vm de (clientte)null geçilebilir demek bu.
            services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });
            return services;
        }
    }
}
