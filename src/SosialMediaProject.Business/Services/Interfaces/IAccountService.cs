using SosialMediaProject.Business.ViewModels;

namespace SosialMediaProject.Business.Services.Interfaces
{
    public interface IAccountService
    {
        Task Login(LoginViewModel loginViewModel);
        Task Logout();
        Task Register(RegisterViewModel registerViewModel);
    }
}
