using MessengerV3.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerV3.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; }
        public string? AboutUser { get; set; }

        public ICollection<ChatDTO> Chats { get; set; }
        public ICollection<MessageDTO> Messages { get; set; }
        public ICollection<ChatDTO> ChatsNavigation { get; set; }

    }
}
