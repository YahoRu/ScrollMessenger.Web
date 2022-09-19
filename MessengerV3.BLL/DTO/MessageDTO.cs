using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerV3.BLL.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public int MessageSenderId { get; set; }
        public string MessageText { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
