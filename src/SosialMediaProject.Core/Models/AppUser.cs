using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosialMediaProject.Core.Models
{
	public class AppUser:IdentityUser
	{
		[Required]
		[StringLength(maximumLength: 100), MinLength(3)]
		public string FullName { get; set; }
	}
}
