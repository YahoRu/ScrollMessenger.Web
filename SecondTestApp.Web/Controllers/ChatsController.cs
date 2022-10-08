using Mapster;
using MessengerV3.BLL.DTO;
using MessengerV3.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var currentUserViewModel = _userService.GetByName(currentUserName);

            //Context.Entry(entity).State = EntityState.Detached // TODO >???
            createChatViewModel.CreatorId = currentUserViewModel.Id;
            createChatViewModel.Creator = currentUserViewModel.Adapt<UserViewModel>();

            var userToAdd = _userService.GetByName(createChatViewModel.UserNameToAdd).Adapt<UserViewModel>();
            if (userToAdd is null) return RedirectToAction("UserNotFound", "Users");
 
            if (ModelState.IsValid) return RedirectToAction("Index");

            createChatViewModel.Users = new List<UserViewModel>();
            createChatViewModel.Messages = new List<MessageViewModel>();
            createChatViewModel.Users.Add(userToAdd);
            var result = createChatViewModel.Adapt<ChatDTO>();
            _chatService.CreateChat(result);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateChat()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OpenChat()
        {
            return View();
        }
    }
}
