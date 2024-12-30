using E_Commerce.Application.Interfaces;
using E_Commerce.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var products = _productService.GetProducts().ToList();


        return Ok(products);
    }
}