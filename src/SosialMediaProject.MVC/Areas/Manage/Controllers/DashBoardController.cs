using Microsoft.AspNetCore.Mvc;

namespace SosialMediaProject.MVC.Areas.Manage.Controllers
{
	[Area("manage")]
	public class DashBoardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
