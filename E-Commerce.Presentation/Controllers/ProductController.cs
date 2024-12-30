using E_Commerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var products = _productService.GetProducts();
        return Ok(products);
    }
}