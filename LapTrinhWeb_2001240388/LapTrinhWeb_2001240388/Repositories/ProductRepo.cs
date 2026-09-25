using LapTrinhWeb_2001240388.Models.Buoi6;
using Microsoft.Data.SqlClient;

namespace LapTrinhWeb_2001240388.Repositories
{
    public class ProductRepo: IProductRepo
    {
        private readonly string _connectionString;
        public ProductRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("conn2");
        }

        public async Task<bool> CreateProdAsync(Product prod)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "INSERT INTO product (ProName, Price, Discount, CreatedAt, Img, CatId) VALUES (@ProName, @Price, @Discount, @CreatedAt, @Img, @CatId)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProName", prod.ProName);
                    command.Parameters.AddWithValue("@Price", prod.Price);
                    command.Parameters.AddWithValue("@Discount", prod.Discount);
                    command.Parameters.AddWithValue("@CreatedAt", prod.CreatedAt);
                    command.Parameters.AddWithValue("@Img", prod.Img);
                    command.Parameters.AddWithValue("@CatId", prod.CatId);
                    int rows = await command.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
        }

        public async Task<bool> DeleteProdAsync(int? id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "DELETE FROM product WHERE ProId = @id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int rows = await command.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync(int? catId = null)
        {
            var list = new List<Product>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT p.ProId, p.ProName, p.Price, p.Discount, p.CreatedAt, p.Img, p.CatId, c.CatName FROM product p LEFT JOIN category c ON p.CatId = c.CatId";
                if (catId.HasValue)
                {
                    query += " WHERE p.CatId = @catId";
                }
                query += " ORDER BY p.ProId DESC";
                using (var command = new SqlCommand(query, connection))
                {
                    if (catId.HasValue)
                    {
                        command.Parameters.AddWithValue("@catId", catId.Value);
                    }
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            list.Add(new Product
                            {
                                ProId = Convert.ToInt32(reader["ProId"]),
                                ProName = reader["ProName"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]),
                                Discount = Convert.ToDecimal(reader["Discount"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                                Img = reader["Img"].ToString(),
                                CatId = Convert.ToInt32(reader["CatId"]),
                                CatName = reader["CatName"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public async Task<Product> GetbyIdAsync(int? id)
        {
            if (!id.HasValue) return null;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT p.ProId, p.ProName, p.Price, p.Discount, p.CreatedAt, p.Img, p.CatId, c.CatName FROM product p LEFT JOIN category c ON p.CatId = c.CatId WHERE p.ProId = @id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id.Value);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Product
                            {
                                ProId = Convert.ToInt32(reader["ProId"]),
                                ProName = reader["ProName"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]),
                                Discount = Convert.ToDecimal(reader["Discount"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                                Img = reader["Img"].ToString(),
                                CatId = Convert.ToInt32(reader["CatId"]),
                                CatName = reader["CatName"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public async Task<bool> UpdateProdAsync(Product prod)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "UPDATE product SET ProName = @ProName, Price = @Price, Discount = @Discount, CreatedAt = @CreatedAt, Img = @Img, CatId = @CatId WHERE ProId = @ProId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProName", prod.ProName);
                    command.Parameters.AddWithValue("@Price", prod.Price);
                    command.Parameters.AddWithValue("@Discount", prod.Discount);
                    command.Parameters.AddWithValue("@CreatedAt", prod.CreatedAt);
                    command.Parameters.AddWithValue("@Img", prod.Img);
                    command.Parameters.AddWithValue("@CatId", prod.CatId);
                    command.Parameters.AddWithValue("@ProId", prod.ProId);
                    int rows = await command.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
        }
    }
}
