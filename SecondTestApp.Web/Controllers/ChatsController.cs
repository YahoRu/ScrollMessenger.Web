using Mapster;
using MessengerV3.BLL.DTO;
using MessengerV3.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ScrollMessenger.Web.Models;
using SecondTestApp.Web.Models;
using System.Linq;
using System.Security.Claims;

namespace SecondTestApp.Web.Controllers
{
    public class ChatsController : Controller
    {
        private IChatService _chatService;
        private IUserService _userService;

        public ChatsController(IChatService chatService, IUserService userService)
        {
            _chatService = chatService;
            _userService = userService;
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
            ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.Name).Value;
            createChatViewModel.CreatorId = _userService.GetByName(currentUserName).Id;

            var userToAdd = _userService.GetByName(createChatViewModel.UserNameToAdd).Adapt<UserViewModel>();
            if (userToAdd is null) return RedirectToAction("UserNotFound", "Users");
 
            if (ModelState.IsValid) return RedirectToAction("Index");

            createChatViewModel.Users = new List<UserViewModel>();
            createChatViewModel.Users.Add(userToAdd);
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
