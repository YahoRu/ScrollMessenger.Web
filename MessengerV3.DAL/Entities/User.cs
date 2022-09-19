using System;
using System.Collections.Generic;

namespace MessengerV3.DAL.Entities
{
    public partial class User
    {
        public User()
        {
            Chats = new HashSet<Chat>();
            Messages = new HashSet<Message>();
            ChatsNavigation = new HashSet<Chat>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? AboutUser { get; set; }

        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Chat> ChatsNavigation { get; set; }
    }
}
