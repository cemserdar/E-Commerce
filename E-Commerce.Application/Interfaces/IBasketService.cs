using E_Commerce.Domain.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace E_Commerce.Application.Interfaces;

public interface IBasketService
{

    void AddToBasket(int userId, int productId, string productName, int quantity, decimal price);
    Basket GetBasket(int userId);
    void RemoveFromBasket(int userId, int productId);
}