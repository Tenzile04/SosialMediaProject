using SosialMediaProject.Core.Models;
using System.Linq.Expressions;

namespace SosialMediaProject.Business.Services.Interfaces
{
	public interface IPostService
	{		
		Task Create(Post post);
		//Task Update(Post post);
		Task Delete(int id);
		Task SoftDelete(int id);
		Task<Post> GetById(Expression<Func<Post, bool>>? expression = null, params string[]? includes);
		Task<List<Post>> GetAll(Expression<Func<Post, bool>>? expression = null, params string[]? includes);
	}
}
