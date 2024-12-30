using E_Commerce.Infrastructure.Data;

namespace E_Commerce.Infrastucture.Repositories;

public class BasketRepository
{
    private readonly ECommerceDbContext _context;

    public BasketRepository(ECommerceDbContext context)
    {
        _context = context;
    }

    public void GetBasket()
    {
        // Get basket logic
    }
}