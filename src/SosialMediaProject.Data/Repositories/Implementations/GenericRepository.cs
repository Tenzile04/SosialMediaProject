using Microsoft.EntityFrameworkCore;
using SosialMediaProject.Core.Models;
using SosialMediaProject.Core.Repositories.Interfaces;
using SosialMediaProject.Data.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SosialMediaProject.Data.Repositories.Implementations
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
	{
		private readonly AppDbContext _context;

		public GenericRepository(AppDbContext context)
		{
			_context = context;
		}
		public DbSet<TEntity> Table => _context.Set<TEntity>();

		public async Task<int> CommitAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public async Task CreateAsync(TEntity entity)
		{
			await Table.AddAsync(entity);
		}

		public void Delete(TEntity entity)
		{
			Table.Remove(entity);
		}

		public IQueryable<TEntity> GetAllAsync(params string[]? includes)
		{
			var query = GetQuery(includes);
			return query;
		}

		public IQueryable<TEntity> GetAllWhereAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? includes)
		{
			var query = GetQuery(includes);
			return expression is not null ? query.Where(expression) : query;
		}

		public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? includes)
		{
			var query = GetQuery(includes);
			return expression is not null
				? await query.Where(expression).FirstOrDefaultAsync()
				: await query.FirstOrDefaultAsync();
		}
		private IQueryable<TEntity> GetQuery(params string[]? includes)
		{
			var query = Table.AsQueryable();
			if (includes is not null)
			{
				foreach (var include in includes)
				{
					query.Include(include);

				}
			}
			return query;
		}

	}
}
