using Microsoft.AspNetCore.Mvc;
using LapTrinhWeb_2001240388.Repositories;
using LapTrinhWeb_2001240388.Models.Buoi6;  

namespace LapTrinhWeb_2001240388.Controllers.Buoi6
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepo.GetAllCategoriesAsync();
            return View(categories);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category cat)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepo.CreateCatAsync(cat);
                return RedirectToAction(nameof(Index));
            }
            return View(cat);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var cat = await _categoryRepo.GetbyIdAsync(id);
            if(cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category cat)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepo.UpdateCatAsync(cat);
                return RedirectToAction(nameof(Index));
            }
            return View(cat);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var cat = await _categoryRepo.GetbyIdAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            await _categoryRepo.DeleteCatAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
