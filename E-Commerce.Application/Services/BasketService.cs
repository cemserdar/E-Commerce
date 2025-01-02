using E_Commerce.Application.Interfaces;
using E_Commerce.Domain.Models;
using E_Commerce.Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Services;

public class BasketService : IBasketService
{
    private readonly BasketRepository basketRepository;

    public BasketService(BasketRepository basketRepository)
    {
        this.basketRepository = basketRepository;
    }

    public void AddToBasket(int userId, int productId, string productName, int quantity, decimal price)
    {
       basketRepository.AddToBasket(userId, productId, productName, quantity, price);
    }

    public Basket GetBasket(int userId)
    {
      return basketRepository.GetBasket(userId);
    }

    public void RemoveFromBasket(int userId, int productId)
    {
      basketRepository.RemoveFromBasket(userId, productId);
    }
}