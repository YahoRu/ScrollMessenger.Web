using System.ComponentModel.DataAnnotations;

namespace SecondTestApp.Web.Models
{
    public class CreateChatViewModel
    {
        [Required]
        public string? ChatName { get; set; }
        [Required]
        public bool MultipleChat { get; set; }
        [Required]
        public int CreatorId { get; set; }
    }
}
