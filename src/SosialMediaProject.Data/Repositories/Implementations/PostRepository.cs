using SosialMediaProject.Core.Models;
using SosialMediaProject.Core.Repositories.Interfaces;
using SosialMediaProject.Data.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosialMediaProject.Data.Repositories.Implementations
{
	public class PostRepository : GenericRepository<Post>, IPostRepository
	{
		public PostRepository(AppDbContext context) : base(context)
		{
		}
	}
}
