using System.Security.Claims;
using Mapster;
using MessengerV3.BLL.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecondTestApp.Web.Models;

namespace SecondTestApp.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
    
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View("Error");

            var user = AuthenticateUser(loginViewModel.Name);

            var claim = new List<Claim>
            {
                new(ClaimTypes.Name, loginViewModel.Name)
            };

            var claimsIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties { };

            await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

            return RedirectToAction("AuthorizedView");
        }

        public IActionResult AuthorizedView()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult NotAuthorizedView()
        {
            return View();
        }


        public IActionResult Failed()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private UserViewModel? AuthenticateUser(string name)
        {
            // TODO return UsersController.StaticUsers.FirstOrDefault(model => model.Name.Equals(name));

            return _userService.GetAllUsers().FirstOrDefault(model => model.Equals(name)).Adapt<UserViewModel>();
        }
    }
}
