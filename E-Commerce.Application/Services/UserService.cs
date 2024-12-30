using E_Commerce.Application.Interfaces;
using E_Commerce.Domain.Models;
using E_Commerce.Infrastucture.Repositories;

namespace E_Commerce.Application.Services;

public class UserService : IUserService
{
    private readonly UserRepository _repository;

    public UserService(UserRepository repository)
    {
        _repository = repository;
    }

    public bool UserCheck(string username, string password)
    {
        return _repository.UserCheck(username, password);
    }

    public User AddUser(User user)
    {
        return _repository.AddUser(user);
    }
}