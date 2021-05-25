using System.ComponentModel.DataAnnotations;

namespace SanriJP.API.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "User PhoneNumber is required")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        //[Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "PromoCode is required")]
        public string PromoCode { get; set; }
    }
}
