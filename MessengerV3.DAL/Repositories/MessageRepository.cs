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
    public class MessageRepository : IMessageRepository<Message>
    {
        private MessengerV3DbContext _db;

        public MessageRepository(MessengerV3DbContext db)
        {
            this._db = db;
        }

        public IEnumerable<Message> GetAll()
        {
            return _db.Messages.ToList(); // !!!
        }

        public Message Get(int id)
        {
            return _db.Messages.Find(id);
        }

        public void Create(Message message)
        {
            _db.Messages.Add(message);
        }

        public void Update(Message message)
        {
            _db.Entry(message).State = EntityState.Modified;
        }

        public IEnumerable<Message> Find(Func<Message, bool> predicate)
        {
            return _db.Messages.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Message message = _db.Messages.Find(id);
            if (message != null) _db.Messages.Remove(message);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
