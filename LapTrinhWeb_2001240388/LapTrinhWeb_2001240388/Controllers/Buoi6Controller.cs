using Microsoft.AspNetCore.Mvc;
using LapTrinhWeb_2001240388.Repositories;

namespace LapTrinhWeb_2001240388.Controllers
{
    public class Buoi6Controller : Controller
    {
        private readonly IProductRepo _productRepo;

        public Buoi6Controller(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<IActionResult> Index(int? catId)
        {
            var products = await _productRepo.GetAllProductAsync(catId);
            return View(products);
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
