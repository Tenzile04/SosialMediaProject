using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SosialMediaProject.Core.Models
{
    public class AppUser:IdentityUser
	{
		[Required]
		[StringLength(maximumLength: 100, MinimumLength=3)]
		public string FullName { get; set; }
		[Required]
		public string Birthdate { get; set; }
		[Required]
		public string Gender { get; set; }
        [Required]
        [StringLength(maximumLength: 100), MinLength(2)]
        public string? Profession { get; set; }
        [Required]
		[StringLength(maximumLength: 100), MinLength(3)]
		public string? Address { get; set; }

		[StringLength(maximumLength: 100)]
		public string? PhotoUrl { get; set; }
		[NotMapped]
		public IFormFile Photo { get; set; }
		[Required]
		public bool IsPublic { get; } = true;

        public bool Status { get; } = true;
        public DateTime RegisteredDate { get; set; }
		//public DateTime LastLoginDate { get; set; }
		public List<Post>? Post {  get; set; }
		public string? ConnectionId { get; set; }

	}
}
