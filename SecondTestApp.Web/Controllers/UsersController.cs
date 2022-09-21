using Mapster;
using MessengerV3.BLL.DTO;
using MessengerV3.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SecondTestApp.Web.Models;

namespace SecondTestApp.Web.Controllers
{
    public class UsersController : Controller
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService; 
        }

        public IActionResult Index()
        {
            var users = _userService.GetAllUsers();
            var usersViewModel = new UsersViewModel { Users = users.Adapt<IList<UserViewModel>>() };

            return View(usersViewModel);
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserViewModel createUserViewModel)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");

            var nameCheck = _userService.ifUserNameExists(createUserViewModel.Name);
            var emailCheck = _userService.ifUserEmailExists(createUserViewModel.Email);

            if(!nameCheck && !emailCheck)
            {
                var newUser = createUserViewModel.Adapt<UserDTO>();
                _userService.CreateUser(newUser);
            }

            return RedirectToAction("Index");   
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
    }
}
