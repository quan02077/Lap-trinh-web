using LapTrinhWeb_2001240388.Models.Buoi6;

namespace LapTrinhWeb_2001240388.Repositories
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAllProductAsync(int? catId = null);
        Task<Product> GetbyIdAsync(int? id);
        Task<bool> CreateProdAsync(Product prod);
        Task<bool> UpdateProdAsync(Product prod);
        Task<bool> DeleteProdAsync(int? id);
    }
}
