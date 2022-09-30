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
    public class UserRepository : IUserRepository<User>
    {
        private MessengerV3DbContext _db;

        public UserRepository(MessengerV3DbContext db)
        {
            _db = db;
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users;
        }

        public User Get(int id)
        {
            return _db.Users.Find(id);
        }

        public void Create(User user)
        {
            _db.Users.Add(user);
        }

        public void Update(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return _db.Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            User user = _db.Users.Find(id);
            if (user != null) _db.Users.Remove(user);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
