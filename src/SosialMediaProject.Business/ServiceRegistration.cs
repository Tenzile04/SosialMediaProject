using Microsoft.Extensions.DependencyInjection;
using SosialMediaProject.Business.Services.Implementations;
using SosialMediaProject.Business.Services.Interfaces;

namespace SosialMediaProject.Business
{
    public static class ServiceRegistration
    {
        public static void AddService(this IServiceCollection services)
        {
          
            services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IPostService, PostService>();
		}
    }
}
