using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SosialMediaProject.Business.Exceptions;
using SosialMediaProject.Business.Services.Interfaces;
using SosialMediaProject.Business.ViewModels;
using SosialMediaProject.Core.Models;
using System.Security.Authentication;

namespace SosialMediaProject.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAccountService _accountService;
        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, IAccountService accountService)
        {
           
            _userManager = userManager;
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);
            try
            {
                await _accountService.Login(loginViewModel);
            }
            catch (InvalidCredentialException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(loginViewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(loginViewModel);
            }
            return RedirectToAction("index", "home");
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();

            return RedirectToAction("login", "account");
        }
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
		{
			if (!ModelState.IsValid) return View(registerViewModel);
			try
			{
				await _accountService.Register(registerViewModel);
			}
			catch (InvalidRegisterException ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(registerViewModel);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(registerViewModel);
			}
			return RedirectToAction("index", "home");
		}
	}
}
