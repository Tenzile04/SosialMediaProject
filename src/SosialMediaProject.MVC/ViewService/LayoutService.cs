using Microsoft.AspNetCore.Identity;
using SosialMediaProject.Core.Models;
using SosialMediaProject.Data.DataAccessLayer;

namespace SosialMediaProject.MVC.ViewService
{
	public class LayoutService
	{
		private readonly AppDbContext _context;
		private readonly UserManager<AppUser> _userManager;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public LayoutService(AppDbContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
		{
			_context = context;
			_userManager = userManager;
			_httpContextAccessor = httpContextAccessor;
		}
		public async Task<AppUser> GetAppUser()
		{
			AppUser user = null;
			if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
			{
				string username = _httpContextAccessor.HttpContext.User.Identity.Name;
				user = await _userManager.FindByNameAsync(username);
			}

			return user;
		}
	}
}
