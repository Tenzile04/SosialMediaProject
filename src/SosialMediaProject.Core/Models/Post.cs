using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SosialMediaProject.Core.Models
{
	public class Post:BaseEntity
	{
		[Required]
		public string Context { get; set; }

		[StringLength(maximumLength: 100)]
		public string? ImageUrl { get; set; }
		[NotMapped]
		public IFormFile Image { get; set; }

		[StringLength(maximumLength: 100)]
		public string? VideoUrl {  get; set; }
		[NotMapped]
		public IFormFile Video { get; set; }
		[Required]
		public bool Status { get; set; }
		public int AppUserId { get; set; }
		public AppUser? AppUser { get; set; }
		
	}
}
