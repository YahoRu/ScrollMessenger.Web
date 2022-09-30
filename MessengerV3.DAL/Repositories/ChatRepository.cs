using MessengerV3.DAL.Entities;
using MessengerV3.DAL.EntitiyFramework;
using MessengerV3.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using ScrollMessenger.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerV3.DAL.Repositories
{
    public class ChatRepository : IChatRepository<Chat>
    {
        private readonly MessengerV3DbContext _db;

        public ChatRepository(MessengerV3DbContext db)
        {
            _db = db;
        }

        public IEnumerable<Chat> GetAll()
        {
            return _db.Chats.Include(x => x.Creator);
        }

        public Chat Get(int id)
        {
            return _db.Chats.Find(id);
        }

        public void Create(Chat chat)
        {
            _db.Chats.Add(chat);
        }

        public void Update(Chat chat)
        {
            _db.Entry(chat).State = EntityState.Modified;
        }

        public IEnumerable<Chat> Find(Func<Chat, bool> predicate)
        {
            return _db.Chats.Include(x => x.Users).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Chat chat = _db.Chats.Find(id);
            if (chat != null) _db.Chats.Remove(chat);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
