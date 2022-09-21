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

            var userCheckName = _userService.ifUserNameExists(loginViewModel.Name);
            var PasswordCheck = _userService.PasswordCheck(loginViewModel.Name, loginViewModel.Password);

            if(!userCheckName && !PasswordCheck) return RedirectToAction("Failed");

            var user = AuthenticateUser(loginViewModel.Name, loginViewModel.Password);

            var claim = new List<Claim>
            {
                new(ClaimTypes.Name, loginViewModel.Name),
                new("Password", loginViewModel.Password)
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
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private UserViewModel? AuthenticateUser(string name, string password)
        {
            return _userService.GetAllUsers()
                .FirstOrDefault(model => model.Name.Equals(name) && model.Password.Equals(password)).Adapt<UserViewModel>();
        }
    }
}
