using E_Commerce.Domain.Models;

namespace E_Commerce.Application.Interfaces;

public interface IProductService
{
    List<Product> GetProducts();
}