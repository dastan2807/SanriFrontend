using System;
using System.ComponentModel.DataAnnotations;

namespace SanriJP.API.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class CreateEmployeeRequest
    {
        [Required(ErrorMessage = "FullName is Required")]
        [StringLength(30, MinimumLength = 3)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Login is Required")]
        [StringLength(15, MinimumLength = 3)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(12, MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is Required")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Role is Required")]
        public string Role { get; set; }
    }
}
