using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanriJP.API.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Service { get; set; }
        public string AtWhatPrice { get; set; }
        public string SizeFOB { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Confirm { get; set; }
        public DateTime CreatedAt { get; set; }

    }
    public class CreateClientRequest
    {
        [Required(ErrorMessage = "FullName is Required")]
        [StringLength(30, MinimumLength = 3)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Country is Required")]
        [StringLength(30, MinimumLength = 3)]
        public string Country { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "PhoneNumber is Required")]
        [StringLength(15, MinimumLength = 5)]
        public string PhoneNumber { get; set; }
        public string Service { get; set; }
        public string AtWhatPrice { get; set; }
        public string SizeFOB { get; set; }

        [Required(ErrorMessage = "Login is Required")]
        [StringLength(12, MinimumLength = 4)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(12, MinimumLength = 4)]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is Required")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
