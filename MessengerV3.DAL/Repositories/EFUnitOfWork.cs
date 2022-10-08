using MessengerV3.DAL.Entities;
using MessengerV3.DAL.EntitiyFramework;
using MessengerV3.DAL.Repositories;
using ScrollMessenger.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollMessenger.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    { 
        private readonly MessengerV3DbContext _db;
        private ChatRepository _chatRepository;
        private UserRepository _userRepository;
        private MessageRepository _messageRepository;

        public EFUnitOfWork(MessengerV3DbContext db)
        {
            _db = db;
        }

        public IUserRepository<User> Users
        {
            get
            {
                if (_userRepository == null) _userRepository = new UserRepository(_db);
                return _userRepository;
            }
        }

        public IChatRepository<Chat> Chats
        {
            get
            {
                if (_chatRepository == null) _chatRepository = new ChatRepository(_db);
                return _chatRepository;
            }
        }

        public IMessageRepository<Message> Messages
        {
            get
            {
                if (_messageRepository == null) _messageRepository = new MessageRepository(_db);
                return _messageRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
