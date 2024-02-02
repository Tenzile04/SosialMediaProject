using Microsoft.EntityFrameworkCore;
using SosialMediaProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SosialMediaProject.Core.Repositories.Interfaces
{
	public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
	{
		DbSet<TEntity> Table { get; }
		Task<int> CommitAsync();
		Task CreateAsync(TEntity entity);
		void Delete(TEntity entity);
		Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? includes);
		IQueryable<TEntity> GetAllWhereAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? includes);
		IQueryable<TEntity> GetAllAsync(params string[]? includes);
	}
}
