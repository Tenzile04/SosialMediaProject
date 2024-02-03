using SosialMediaProject.Core.Models;

namespace SosialMediaProject.MVC.ViewModels
{
	public class HomeViewModel
	{
		public List<AppUser> AppUsers { get; set; }
		public List<Post> Posts { get; set; }
	}
}
