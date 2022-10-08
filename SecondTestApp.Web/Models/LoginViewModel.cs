using System.ComponentModel.DataAnnotations;

namespace SecondTestApp.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public int Id { get; set; }
    }
}
