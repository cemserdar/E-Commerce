using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using E_Commerce.Infrastructure.Data;
using System.Linq;
using E_Commerce.Domain.Models;
using E_Commerce.Application.Interfaces;
using static E_Commerce.Domain.Models.User;
using E_Commerce.Domain.ViewModel;

namespace E_Commerce.Presentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly ECommerceDbContext _context;
        private readonly IUserService _userService;

        public LoginController(ECommerceDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Email and password are required.");
                return View();
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim("Role", user.Role.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                              new ClaimsPrincipal(claimsIdentity),
                                              authProperties);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid email or password.");
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var newUser = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password, 
                    Address = model.Address,
                    Telefon = model.Telefon,
                    Role = (int)UserRole.StandardUser 
                };

                var isEmailExists = _context.Users.Any(u => u.Email == model.Email);
                if (isEmailExists)
                {
                    ModelState.AddModelError("", "Email is already registered.");
                    return View(model); 
                }

                _userService.AddUser(newUser);

                return RedirectToAction("Login");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
