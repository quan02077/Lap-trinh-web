using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using shopweb3.Models;
using shopweb3.Repositories;
using shopweb3.ViewModels;

namespace MyStoreApp.Areas.Admin.Controllers
{
    [Area("Admin")] 
    //Nhãn Admin: "Controller này thuộc về khu vực Admin, không phải khu vực mặc định"
    //Sử dụng trong program.cs
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IWebHostEnvironment _environment;

        public ProductController(IProductRepository productRepo, ICategoryRepository categoryRepo, IWebHostEnvironment environment)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _environment = environment;
        }

        public async Task<IActionResult> Index() =>
            View(await _productRepo.GetAllAsync());

        public async Task<IActionResult> Create()
        {
            ViewBag.CatId = new SelectList(await _categoryRepo.GetAllAsync(), "CatId", "CatName");
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

                await _productRepo.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CatId = new SelectList(await _categoryRepo.GetAllAsync(), "CatId", "CatName", model.CatId);
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
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

            ViewBag.CatId = new SelectList(await _categoryRepo.GetAllAsync(), "CatId", "CatName", product.CatId);
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

                await _productRepo.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CatId = new SelectList(await _categoryRepo.GetAllAsync(), "CatId", "CatName", model.CatId);
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}