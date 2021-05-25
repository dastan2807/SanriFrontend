using System.ComponentModel.DataAnnotations;

namespace SanriJP.API.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Login is Required")]
        [StringLength(12, MinimumLength = 4)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(12, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
