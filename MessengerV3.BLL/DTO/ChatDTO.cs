using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerV3.BLL.DTO
{
    public class ChatDTO
    {
        public int Id { get; set; }
        public string ChatName { get; set; }
        public bool MultipleChat { get; set; }
        public int CreatorId { get; set; }
    }
}
