using AnimalsWeb.Client.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace AnimalsWeb.Client.Controllers
{
    public class AccountController : Controller
    {
        private readonly IOptions<List<UserToLogin>> _users;
        public AccountController(IOptions<List<UserToLogin>> users)
        {
            _users = users;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserToLogin userToLogin)
        {
            var user = _users.Value.Find(c => c.UserName == userToLogin.UserName && c.Password == userToLogin.Password);

            if (user is not null)
            {
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name,userToLogin.UserName),
                new Claim("FullName", userToLogin.UserName),
                new Claim(ClaimTypes.Role, "Administrator"),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    RedirectUri = "/Admin/List",
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return Redirect(authProperties.RedirectUri);
            }

            return Redirect(nameof(Login));
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
