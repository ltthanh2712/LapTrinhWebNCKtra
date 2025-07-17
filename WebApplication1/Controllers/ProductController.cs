using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _env;
        public ProductController(IProductService productService, IWebHostEnvironment env)
        {
            _productService = productService;
            _env = env;
        }
        public IActionResult DetailProduct()
        {
            var firstProduct = _productService.GetFirstProducts();
            return View(firstProduct);
        }
        public IActionResult EditProduct(int id)
        {
            var product = _productService.GetFirstProducts();
            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(id, product, _env.WebRootPath);
                return RedirectToAction("DetailProduct");
            }
            return View(product);
        }
    }
}
