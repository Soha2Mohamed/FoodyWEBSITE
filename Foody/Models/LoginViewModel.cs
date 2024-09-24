using System.ComponentModel.DataAnnotations;

namespace Foody.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is requird")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is requird")]
        public string Password { get; set; }
    }
}
