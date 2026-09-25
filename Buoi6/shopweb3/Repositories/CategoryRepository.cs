using Microsoft.Data.SqlClient;
using shopweb3.Models;

namespace shopweb3.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _connectionString;

        public CategoryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default")!;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var list = new List<Category>();
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT CatId, CatName FROM category ORDER BY CatId DESC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            list.Add(new Category
                            {
                                CatId = reader.GetInt32(0),
                                CatName = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return list;
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            Category? category = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT CatId, CatName FROM category WHERE CatId = @CatId";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CatId", id);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            category = new Category
                            {
                                CatId = reader.GetInt32(0),
                                CatName = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            return category;
        }

        public async Task<bool> AddAsync(Category category)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO category (CatName) VALUES (@CatName)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CatName", category.CatName);
                    await conn.OpenAsync();
                    int rows = await cmd.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
        }   

        public async Task<bool> UpdateAsync(Category category)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = "UPDATE category SET CatName = @CatName WHERE CatId = @CatId";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CatName", category.CatName);
                    cmd.Parameters.AddWithValue("@CatId", category.CatId);
                    await conn.OpenAsync();
                    int rows = await cmd.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM category WHERE CatId = @CatId";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CatId", id);
                    await conn.OpenAsync();
                    int rows = await cmd.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
        }
    }
}