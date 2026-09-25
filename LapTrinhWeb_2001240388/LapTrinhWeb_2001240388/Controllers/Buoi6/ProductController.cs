using LapTrinhWeb_2001240388.Models.Buoi6;
using LapTrinhWeb_2001240388.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LapTrinhWeb_2001240388.ViewModels;

namespace LapTrinhWeb_2001240388.Controllers.Buoi6
{
    public class ProductController : Controller
    {
        private readonly IProductRepo _productRepo;
        private readonly ICategoryRepo _categoryRepo;
        private readonly IWebHostEnvironment _environment;

        public ProductController(IProductRepo productRepo, ICategoryRepo categoryRepo, IWebHostEnvironment environment)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _environment = environment;
        }
        public async Task<IActionResult> Index() =>
            View(await _productRepo.GetAllProductAsync());

        public async Task<IActionResult> Create()
        {
            ViewBag.CatId = new SelectList(await _categoryRepo.GetAllCategoriesAsync(), "CatId", "CatName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                string? fileName = null;
                if (model.ImageFile != null)
                {
                    fileName = $"{Guid.NewGuid()}_{model.ImageFile.FileName}";
                    string uploadFolder = Path.Combine(_environment.WebRootPath, "images");
                    string filePath = Path.Combine(uploadFolder, fileName);

                    if (!Directory.Exists(uploadFolder)) Directory.CreateDirectory(uploadFolder);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(stream);
                    }
                }

                var product = new Product
                {
                    ProName = model.ProName,
                    Price = model.Price,
                    Discount = model.Discount,
                    Img = fileName,
                    CatId = model.CatId
                };

                await _productRepo.CreateProdAsync(product);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CatId = new SelectList(await _categoryRepo.GetAllCategoriesAsync(), "CatId", "CatName", model.CatId);
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepo.GetbyIdAsync(id);
            if (product == null) return NotFound();

            var model = new ProductViewModel
            {
                ProId = product.ProId,
                ProName = product.ProName,
                Price = product.Price,
                Discount = product.Discount,
                ExistingImg = product.Img,
                CatId = product.CatId
            };

            ViewBag.CatId = new SelectList(await _categoryRepo.GetAllCategoriesAsync(), "CatId", "CatName", product.CatId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                string? fileName = model.ExistingImg;

                if (model.ImageFile != null)
                {
                    fileName = $"{Guid.NewGuid()}_{model.ImageFile.FileName}";
                    string uploadFolder = Path.Combine(_environment.WebRootPath, "images");
                    string filePath = Path.Combine(uploadFolder, fileName);

                    if (!Directory.Exists(uploadFolder)) Directory.CreateDirectory(uploadFolder);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(stream);
                    }
                }

                var product = new Product
                {
                    ProId = model.ProId,
                    ProName = model.ProName,
                    Price = model.Price,
                    Discount = model.Discount,
                    CatId = model.CatId,
                    Img = fileName
                };

                await _productRepo.UpdateProdAsync(product);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CatId = new SelectList(await _categoryRepo.GetAllCategoriesAsync(), "CatId", "CatName", model.CatId);
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepo.GetbyIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productRepo.DeleteProdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
