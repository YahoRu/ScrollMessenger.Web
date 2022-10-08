
using ScrollMessenger.Web.Models;
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
        public int CreatorId { get; set;  }
        [Required]
        public UserViewModel Creator { get; set; }

        public List<MessageViewModel> Messages { get; set; }
        [Required]
        public List<UserViewModel> Users { get; set; }

        public string UserNameToAdd { get; set; } 
    }
}
