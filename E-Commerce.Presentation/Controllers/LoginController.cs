using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using E_Commerce.Infrastructure.Data;
using E_Commerce.Application.Interfaces;

namespace E_Commerce.Presentation.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ECommerceDbContext _context;
        private readonly IUserService _userService;

        public LoginController(ECommerceDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        //[Route("/login")]
        public  IActionResult Login(string username, string password)
        {
           var isExist =  _userService.UserCheck(username,password);

            if (isExist)
            {
                var claims = new List<Claim>
                {
                    //Role 1 Admin
                    new Claim(ClaimTypes.Name, username),
                    new Claim("Role", _context.Users.FirstOrDefault().Role.ToString())
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
                //return View();
            }

            else
            {
                return View();
            }
           
            return Ok("Giriş başarılı.");
            //ViewBag.Error = "Geçersiz kullanıcı adı veya şifre.";
            //return Ok();
        }

        //public async Task<IActionResult> Logout()
        //{
        //    // Kullanıcı oturumu kapatılıyor
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return RedirectToAction("Login", "Account");
        //}

        //public IActionResult AccessDenied()
        //{
        //    return Ok("hata");
        //}
    }
}
