using E_Commerce.Application.Interfaces;
using E_Commerce.Domain.Models;
using E_Commerce.Infrastucture.Repositories;

namespace E_Commerce.Application.Services;

public class CategoryService : ICategoryService
{
    
    private readonly CategoryRepository categoryRepository;

    public CategoryService(CategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public List<Category> GetAllCategories()
    {
        return categoryRepository.GetAllCategories();
    }

}