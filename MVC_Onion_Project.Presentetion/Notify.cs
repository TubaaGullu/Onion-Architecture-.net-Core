using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Onion_Project.Presentation
{
	public class Notify : ViewComponent
	{
        private readonly INotyfService _notifyService;

        public Notify(INotyfService notifyService)
        {
            _notifyService = notifyService;
        }

        public IViewComponentResult Invoke()
        {
            var notifications = _notifyService.GetNotifications();
            return View( notifications); 
        }
    }
}
