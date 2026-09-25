using Microsoft.AspNetCore.Mvc;
using LapTrinhWeb_2001240388.Repositories;

namespace LapTrinhWeb_2001240388.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryMenuViewComponent(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryRepo.GetAllCategoriesAsync();
            return View(categories);
        }
    }
}
