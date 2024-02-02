using System.ComponentModel.DataAnnotations;

namespace SosialMediaProject.Business.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string UserName { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
