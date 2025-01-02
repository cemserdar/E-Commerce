using E_Commerce.Domain.Models;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastucture.Repositories;

public class BasketRepository
{
    private readonly ECommerceDbContext _context;

    public BasketRepository(ECommerceDbContext context)
    {
        _context = context;
    }

    public void AddToBasket(int userId, int productId, string productName, int quantity, decimal price)
    {
        var basket =  _context.Baskets
            .Include(b => b.Items)
            .FirstOrDefault(b => b.UserId == userId);

        if (basket == null)
        {
            basket = new Basket { UserId = userId };
            _context.Baskets.Add(basket);
             _context.SaveChanges();
        }

        var existingItem = basket.Items.FirstOrDefault(i => i.ProductId == productId);
        if (existingItem == null)
        {
            basket.Items.Add(new BasketItem
            {
                ProductId = productId,
                ProductName = productName,
                Quantity = quantity,
                Price = price
            });
        }
        else
        {
            existingItem.Quantity += quantity;
        }

         _context.SaveChangesAsync();
    }

    public Basket GetBasket(int userId)
    {
        return  _context.Baskets
            .Include(b => b.Items)
            .FirstOrDefault(b => b.UserId == userId);
    }

    public void RemoveFromBasket(int userId, int productId)
    {
        var basket =  _context.Baskets
            .Include(b => b.Items)
            .FirstOrDefault(b => b.UserId == userId);

        if (basket != null)
        {
            var itemToRemove = basket.Items.FirstOrDefault(i => i.ProductId == productId);
            if (itemToRemove != null)
            {
                basket.Items.Remove(itemToRemove);
                 _context.SaveChanges();
            }
        }
    }
}