using Mapster;
using MessengerV3.BLL.DTO;
using MessengerV3.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SecondTestApp.Web.Models;

namespace SecondTestApp.Web.Controllers
{
    public class ChatsController : Controller
    {
        private IChatService _chatService;

        public ChatsController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<ChatDTO> chatDtos = _chatService.GetAllChats();
            var chatViewModel = new ChatsViewModel { Chats = chatDtos.Adapt<IList<ChatViewModel>>() };
            return View(chatViewModel);
        }

        [HttpPost]
        public IActionResult CreateChat(CreateChatViewModel createChatViewModel)
        {
            if (ModelState.IsValid) return RedirectToAction("Index"); 
            _chatService.CreateChat(createChatViewModel.Adapt<ChatDTO>());
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateChat()
        {
            return View();
        }
    }
}
