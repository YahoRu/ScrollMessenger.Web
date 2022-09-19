using MessengerV3.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerV3.DAL.Interfaces;
using MessengerV3.BLL.DTO;
using MessengerV3.DAL.Entities;
using Mapster;

namespace MessengerV3.BLL.Services
{
    public class ChatService : IChatService
    {
        private readonly IRepository<Chat> _chatRepository;

        public ChatService(IRepository<Chat> chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public void CreateChat(ChatDTO chatDto)
        {
            var chat = chatDto.Adapt<Chat>();
            _chatRepository.Create(chat);
            _chatRepository.Save();
        }

        public ChatDTO GetChat(int id)
        {
            return _chatRepository.Get(id).Adapt<ChatDTO>();
        }

        public IEnumerable<ChatDTO> GetAllChats()
        {
            var chatEnumerable = _chatRepository.GetAll();
            return chatEnumerable.Adapt<IEnumerable<ChatDTO>>();
        }
    }
}
