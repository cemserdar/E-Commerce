using E_Commerce.Application.Interfaces;
using E_Commerce.Domain.Models;
using E_Commerce.Infrastucture.Repositories;

namespace E_Commerce.Application.Services;

public class ProductService : IProductService
{
    private readonly ProductRepository _productRepository;

    public ProductService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<Product> GetProducts()
    {
        return _productRepository.GetProducts();
    }
}