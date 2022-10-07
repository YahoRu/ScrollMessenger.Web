using Microsoft.AspNetCore.Mvc;

namespace ScrollMessenger.Web.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
