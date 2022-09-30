using MessengerV3.BLL.DTO;
using SecondTestApp.Web.Models;

namespace ScrollMessenger.Web.Models
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public int MessageSenderId { get; set; }
        public string? MessageText { get; set; }
        public DateTime MessageDate { get; set; }

        public ChatViewModel Chat { get; set; }
        public UserViewModel MessageSender { get; set; }
    }
}
