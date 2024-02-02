using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosialMediaProject.Business.ViewModels
{
	public class RegisterViewModel
	{
		[Required]
		[StringLength(maximumLength: 50, MinimumLength = 3)]
		public string UserName { get; set; }
		[Required]
		[StringLength(maximumLength: 100, MinimumLength = 3)]
		public string FullName { get; set; }
		[Required]
		[StringLength(maximumLength: 50, MinimumLength = 3)]
		public string Gender { get; set; }	
		[Required]
		[StringLength(maximumLength: 50)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[StringLength(maximumLength: 20, MinimumLength = 10)]
		public string Phone { get; set; }
		[Required]
		public string Birthdate { get; set; }
		[Required]
		[StringLength(maximumLength: 50, MinimumLength = 8)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

	}
}
