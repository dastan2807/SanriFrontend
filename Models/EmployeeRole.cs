using System.ComponentModel.DataAnnotations;

namespace SanriJP.API.Models
{
    public class EmployeeRole
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Role is Required")]
        public string Name { get; set; }
    }
}
