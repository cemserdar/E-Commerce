using E_Commerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers
{
    public class HomeController : Controller
    {


        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _productService.GetProducts().ToList();


            return View(products);
        }

    }

}
