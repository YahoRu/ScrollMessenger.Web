using MessengerV3.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerV3.BLL.Interfaces
{
    public interface IUserService
    {

        void CreateUser(UserDTO userDto);
        UserDTO GetUser(int userId);
        IEnumerable<UserDTO> GetAllUsers();
    }
}
