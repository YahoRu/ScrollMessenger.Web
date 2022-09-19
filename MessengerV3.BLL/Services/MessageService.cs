using Mapster;
using MessengerV3.BLL.DTO;
using MessengerV3.BLL.Interfaces;
using MessengerV3.DAL.Entities;
using MessengerV3.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerV3.BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> _messageRepository;

        public MessageService(IRepository<Message> messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public void CreateMessage(MessageDTO messageDto)
        {
            var message = messageDto.Adapt<Message>();
            _messageRepository.Create(message);
            _messageRepository.Save();
        }

        public MessageDTO GetMessage(int messageId)
        {
           return _messageRepository.Get(messageId).Adapt<MessageDTO>();
        }

        public IEnumerable<MessageDTO> GetMessages() // TODO
        {
            return null;
        }
    }
}
