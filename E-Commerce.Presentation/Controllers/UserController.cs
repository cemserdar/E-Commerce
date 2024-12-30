using E_Commerce.Application.Interfaces;
using E_Commerce.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost]
    public IActionResult AddUser(User user)
    {
        var result = _userService.AddUser(user);
        return Ok(result);
    }
}