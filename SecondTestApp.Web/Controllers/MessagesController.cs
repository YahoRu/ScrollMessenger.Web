using MessengerV3.BLL.Interfaces;

using Microsoft.AspNetCore.Mvc;
using ScrollMessenger.Web.Models;

namespace ScrollMessenger.Web.Controllers
{
    public class MessagesController : Controller
    {
        private IMessageService _messageRepository;

        public MessagesController(IMessageService messageService)
        {
            _messageRepository = messageService;
        }
        public IActionResult Index()
        { 
            return View(); 
        }

        [HttpPost]
        public IActionResult SendMessage(MessageViewModel messageViewModel)
        {
            return null;
        }
    }
}
