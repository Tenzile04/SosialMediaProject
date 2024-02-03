using Microsoft.AspNetCore.Mvc;
using SosialMediaProject.Data.DataAccessLayer;
using SosialMediaProject.MVC.ViewModels;
using System.Diagnostics;

namespace SosialMediaProject.MVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _context;
		public HomeController(AppDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			HomeViewModel homeViewModel = new HomeViewModel()
			{
				AppUsers = _context.AppUsers.ToList(),
				Posts=_context.Posts.ToList()

			};
			return View(homeViewModel);
		}


	}
}
