using MessengerV3.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerV3.BLL.Interfaces
{
    public interface IMessageService
    {
        void CreateMessage(MessageDTO messageDto);
        MessageDTO GetMessage(int messageId);
        IEnumerable<MessageDTO> GetMessages();
    }
}
