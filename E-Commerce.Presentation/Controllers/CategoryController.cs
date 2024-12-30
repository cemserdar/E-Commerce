using E_Commerce.Application.Interfaces;
using E_Commerce.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult GetAllCategories()
    {
        var categories = _categoryService.GetAllCategories();
        return Ok(categories);
    }
}