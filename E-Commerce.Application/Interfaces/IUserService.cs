using E_Commerce.Domain.Models;

namespace E_Commerce.Application.Interfaces;

public interface IUserService
{
    bool UserCheck(string username, string password);
    User AddUser(User user);
}