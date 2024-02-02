using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SosialMediaProject.Core.Models
{
    public class AppUser:IdentityUser
	{
		[Required]
		[StringLength(maximumLength: 100, MinimumLength=3)]
		public string FullName { get; set; }
	}
}
