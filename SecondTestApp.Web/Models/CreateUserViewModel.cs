using System.ComponentModel.DataAnnotations;

namespace SecondTestApp.Web.Models
{
    public class CreateUserViewModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? AboutUser { get; set; }
    }
}
