using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using SosialMediaProject.Core.Models;

namespace SosialMediaProject.MVC.ViewModels
{
	public class ProfileViewModel
	{
		
		public List<Post> Posts { get; set; }
	}
}
