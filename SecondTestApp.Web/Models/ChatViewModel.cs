using MessengerV3.BLL.DTO;
using MessengerV3.DAL.Entities;
using ScrollMessenger.Web.Models;

namespace SecondTestApp.Web.Models
{
    public class ChatViewModel
    {
        public string? ChatName { get; set; }
        public bool MultipleChat { get; set; }
        public int CreatorId { get; set; }

        public  List<MessageViewModel> Messages { get; set; }
        public  List<UserViewModel> Users { get; set; }
    }
}
