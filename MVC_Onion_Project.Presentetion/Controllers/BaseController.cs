using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Onion_Project.Presentation.Controllers
{
    public class BaseController : Controller
    {
        public INotyfService _notifyService { get; }
        protected readonly IMapper _mapper;


        public BaseController(INotyfService notifyService, IMapper mapper)
        {
            _notifyService = notifyService;
            _mapper = mapper;
        }


        protected void  SuccessNotification(string message)
        {
             _notifyService.Success(message);
        }
        protected void ErrorNotification(string message)
        {
            _notifyService.Error(message);

        }
        protected void WarningNotification(string message)
        {
            _notifyService.Warning(message);

        }
        protected void InformationNotification(string message)
        {
            _notifyService.Information(message);

        }
        protected void CustomNotification(string message)
        {
            _notifyService.Custom(message, 5,  "whitesmoke", "fa fa-gear");
        }


    }
}
