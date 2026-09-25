using LapTrinhWeb_2001240388.Models.Buoi6;
namespace LapTrinhWeb_2001240388.Repositories
{
    public interface ICategoryRepo
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetbyIdAsync(int? id);
        Task<bool> CreateCatAsync(Category cat);
        Task<bool> UpdateCatAsync(Category cat);
        Task<bool> DeleteCatAsync(int? id);
    }
}
