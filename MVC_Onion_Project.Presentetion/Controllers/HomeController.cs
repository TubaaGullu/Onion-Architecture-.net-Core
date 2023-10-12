using Microsoft.AspNetCore.Mvc;

namespace MVC_Onion_Project.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
