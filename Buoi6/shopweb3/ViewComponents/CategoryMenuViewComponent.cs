using Microsoft.AspNetCore.Mvc;
using shopweb3.Repositories;

namespace shopweb3.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryMenuViewComponent(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryRepo.GetAllAsync();
            return View(categories);
        }
    }
}