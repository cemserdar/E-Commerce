using E_Commerce.Application.Interfaces;
using E_Commerce.Infrastucture.Repositories;

namespace E_Commerce.Application.Services;

public class BasketService : IBasketService
{
    private readonly BasketRepository basketRepository;

    public BasketService(BasketRepository basketRepository)
    {
        this.basketRepository = basketRepository;
    }

    public void GetBasket()
    {
        basketRepository.GetBasket();
    }
}