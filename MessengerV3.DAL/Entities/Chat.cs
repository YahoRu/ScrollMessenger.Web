using System;
using System.Collections.Generic;

namespace MessengerV3.DAL.Entities
{
    public partial class Chat
    {
        public Chat()
        {
            Messages = new HashSet<Message>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string ChatName { get; set; } = null!;
        public bool MultipleChat { get; set; }
        public int CreatorId { get; set; }

        public virtual User Creator { get; set; } = null!;
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
