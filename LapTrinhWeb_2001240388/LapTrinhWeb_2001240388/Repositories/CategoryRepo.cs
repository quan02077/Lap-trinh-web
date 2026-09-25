using LapTrinhWeb_2001240388.Models.Buoi6;
using Microsoft.Data.SqlClient;

namespace LapTrinhWeb_2001240388.Repositories
{
    public class CategoryRepo: ICategoryRepo
    {
        private readonly string _connectionString;
        public CategoryRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("conn2");
        }

        public async Task<bool> CreateCatAsync(Category cat)
        {
            using (var connection = new SqlConnection(_connectionString)) {
                await connection.OpenAsync();
                var query = "INSERT INTO category (CatName) VALUES (@CatName)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CatName", cat.CatName);
                    int rows = await command.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
        }

        public async Task<bool> DeleteCatAsync(int? id)
        {
            using (var connection = new SqlConnection(_connectionString)) {
                await connection.OpenAsync();
                var query = "DELETE FROM category WHERE CatId = @id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int rows = await command.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var list = new List<Category>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT CatId, CatName FROM category ORDER BY CatId DESC";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            list.Add(new Category
                            {
                                CatId = Convert.ToInt32(reader["CatId"]),
                                CatName = reader["CatName"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public async Task<Category> GetbyIdAsync(int? id)
        {
            Category? cat = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT CatId, CatName FROM category WHERE CatId = @id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                        {
                            cat = new Category
                            {
                                CatId = Convert.ToInt32(reader["CatId"]),
                                CatName = reader["CatName"].ToString()
                            };

                        }
                    }
                }
            }
            return cat;
        }

        public async Task<bool> UpdateCatAsync(Category cat)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "UPDATE category SET CatName = @CatName WHERE CatId = @CatId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CatName", cat.CatName);
                    command.Parameters.AddWithValue("@CatId", cat.CatId);
                    int rows = await command.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
        }
    }
}
