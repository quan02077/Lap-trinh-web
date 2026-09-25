using Microsoft.AspNetCore.Mvc;
using shopweb3.Repositories;

namespace shopweb3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepo;

        public HomeController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<IActionResult> Index(int? catId)
        {
            var products = await _productRepo.GetAllAsync(catId);
            return View(products);
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}