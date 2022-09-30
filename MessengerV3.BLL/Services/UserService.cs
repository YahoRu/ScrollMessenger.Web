using Mapster;
using MessengerV3.BLL.DTO;
using MessengerV3.BLL.Interfaces;
using MessengerV3.DAL.Entities;
using MessengerV3.DAL.Interfaces;
using ScrollMessenger.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerV3.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> _userRepository;

        public UserService(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(UserDTO userDto)
        {
            var user = userDto.Adapt<User>();
            _userRepository.Create(user);
            _userRepository.Save();
        }        

        public bool ifUserNameExists(string name)
        {
            var allUsers = _userRepository.GetAll();

            foreach (var user in allUsers)
            {
                if (user.Name.Equals(name)) return true;
            }

            return false;
        } 

        public bool ifUserEmailExists(string email)
        {
            var allUsers = _userRepository.GetAll();

            foreach (var user in allUsers)
            {
                if (user.Email.Equals(email)) return true;
            }

            return false;
        }

        public bool PasswordCheck(string userName, string password)
        {
            var allUsers = _userRepository.GetAll();

            foreach (var user in allUsers)
            {
                if (user.Name.Equals(userName) && user.Password.Equals(password)) return true;
            }

            return false;
        }

        public UserDTO GetUser(int userId)
        {
           return _userRepository.Get(userId).Adapt<UserDTO>();
        }

        public IEnumerable<UserDTO> GetAllUsers()  // TODO or delete?
        {
            var users = _userRepository.GetAll();
            return users.Adapt<IEnumerable<UserDTO>>();
        }
    }
}
