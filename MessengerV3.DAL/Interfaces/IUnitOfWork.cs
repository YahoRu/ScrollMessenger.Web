using MessengerV3.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollMessenger.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IChatRepository<Chat> Chats { get; }
        IUserRepository<User> Users { get; }
        IMessageRepository<Message> Messages { get; }
        void Save();
    }
}
