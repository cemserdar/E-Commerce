using E_Commerce.Domain.Models;
using E_Commerce.Infrastructure.Data;

namespace E_Commerce.Infrastucture.Repositories;

public class ProductRepository
{
    private readonly ECommerceDbContext _context;

    public ProductRepository(ECommerceDbContext context)
    {
        _context = context;
    }

    public List<Product> GetProducts()
    {
        return _context.Products.ToList();
    }
}