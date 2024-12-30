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

    public IActionResult Basket()
    {
        _basketService.GetBasket();

        return View();
    }
}