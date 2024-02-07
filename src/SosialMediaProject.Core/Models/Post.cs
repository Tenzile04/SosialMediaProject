using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SosialMediaProject.Core.Models
{
    public class Post:BaseEntity
	{
		[Required]
        [StringLength(maximumLength: 500,MinimumLength =2)]
        public string Context { get; set; }

		[StringLength(maximumLength: 100)]
		public string? FormUrl {  get; set; }
		[NotMapped]
		public IFormFile? FormFile { get; set; }

		public bool Status { get; } = true;
		public string? AppUserId { get; set; }
		public AppUser? AppUser { get; set; }
		
	}
}
