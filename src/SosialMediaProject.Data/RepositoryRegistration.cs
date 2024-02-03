using Microsoft.Extensions.DependencyInjection;
using SosialMediaProject.Core.Repositories.Interfaces;
using SosialMediaProject.Data.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosialMediaProject.Data
{
	public static class RepositoryRegistration
	{
		public static void AddRepository(this IServiceCollection services)
		{
			services.AddScoped<IPostRepository, PostRepository>();
		}
	}
}
