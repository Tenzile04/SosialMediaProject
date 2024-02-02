using Microsoft.AspNetCore.Identity;
using SosialMediaProject.Business.Exceptions;
using SosialMediaProject.Business.Services.Interfaces;
using SosialMediaProject.Business.ViewModels;
using SosialMediaProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosialMediaProject.Business.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task Login(LoginViewModel loginViewModel)
        {
            if (loginViewModel == null) throw new InvalidNotFoundException();

            AppUser admin = null;

            admin = await _userManager.FindByNameAsync(loginViewModel.UserName);

            if (admin == null)
            {
                throw new InvalidCredentionalException("", "UserName or Password is incorrect");

            }
            var result = await _signInManager.PasswordSignInAsync(admin, loginViewModel.Password, false, false);

            if (!result.Succeeded)
            {
                throw new InvalidCredentionalException("", "UserName or Password is incorrect");
            }

        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

		public async Task Register(RegisterViewModel registerViewModel)
		{
			AppUser user = null;

			user = await _userManager.FindByNameAsync(registerViewModel.UserName);
			if (user is not null)
			{
				throw new InvalidRegisterException("Username", "Username already exist!");
				
			}
			user = await _userManager.FindByEmailAsync(registerViewModel.Email);

			if (user is not null)
			{
				throw new InvalidRegisterException("Email", "Email already exist!");
				
			}
			AppUser appUser = new AppUser
			{
				FullName=registerViewModel.FullName,
				UserName = registerViewModel.UserName,
				Gender=registerViewModel.Gender,	
				PhoneNumber=registerViewModel.Phone,
				Email = registerViewModel.Email,
				Birthdate = registerViewModel.Birthdate

			};
			var result = await _userManager.CreateAsync(appUser, registerViewModel.Password);

			if (result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					throw new InvalidRegisterException("", error.Description);
					
				}
			}
			await _userManager.AddToRoleAsync(appUser, "Member");
			await _signInManager.SignInAsync(appUser, isPersistent: false);

			
		}
	}
}
