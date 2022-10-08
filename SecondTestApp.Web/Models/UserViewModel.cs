using MessengerV3.DAL.Entities;

namespace SecondTestApp.Web.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? AboutUser { get; set; }

        public  List<Chat> Chats { get; set; }
        public  List<Message> Messages { get; set; }
        public  List<Chat> ChatsNavigation { get; set; }
    }
}
