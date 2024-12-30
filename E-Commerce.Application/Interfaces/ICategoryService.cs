using E_Commerce.Domain.Models;

namespace E_Commerce.Application.Interfaces;

public interface ICategoryService
{
    List<Category> GetAllCategories();
}