using E_Commerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers;

public class BasketController : Controller
{

    private readonly IBasketService _basketService;

    public BasketController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public IActionResult Index()
    {
        int userId = GetCurrentUserId();
        var basket = _basketService.GetBasket(userId);
        return View(basket);
    }

    [HttpPost]
    public IActionResult AddToBasket(int productId, string productName, int quantity, decimal price)
    {
        int userId = GetCurrentUserId();
        _basketService.AddToBasket(userId, productId, productName, quantity, price);
        return RedirectToAction("Index");
    }

    // Sepetten Ürün Çýkar
    public IActionResult RemoveFromBasket(int productId)
    {
        int userId = GetCurrentUserId();
        _basketService.RemoveFromBasket(userId, productId);
        return RedirectToAction("Index");
    }

    private int GetCurrentUserId()
    {
        return 1; // Oturumdaki kullanýcýnýn kimliðini alýn
    }
}
