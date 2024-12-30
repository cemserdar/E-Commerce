using E_Commerce.Domain.Models;
using E_Commerce.Infrastructure.Data;

namespace E_Commerce.Infrastucture.Repositories;

public class CategoryRepository
{
    private readonly ECommerceDbContext _context;

    public CategoryRepository(ECommerceDbContext context)
    {
        _context = context;
    }

    public List<Category> GetAllCategories()
    {
        return _context.Categories.ToList();
    }



}