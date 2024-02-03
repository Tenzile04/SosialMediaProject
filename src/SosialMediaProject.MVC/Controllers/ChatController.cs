using Microsoft.AspNetCore.Mvc;

namespace SosialMediaProject.MVC.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
