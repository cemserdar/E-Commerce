using E_Commerce.Domain.Models;
using E_Commerce.Infrastructure.Data;

namespace E_Commerce.Infrastucture.Repositories;

public class UserRepository
{

    private readonly ECommerceDbContext context;

    public UserRepository(ECommerceDbContext context)
    {
        this.context = context;
    }

    public bool UserCheck(string username, string password)
    {
        var user = context.Users.Any(x => x.Email == username && x.Password == password);

        return user;
    }
}