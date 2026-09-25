using Microsoft.Data.SqlClient;
using shopweb3.Models;

namespace shopweb3.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default")!;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(int? catId = null)
        {
            var list = new List<Product>();
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT p.ProId, p.ProName, p.Price, p.Discount, p.CreatedAt, p.Img, p.CatId, c.CatName 
                    FROM product p 
                    LEFT JOIN category c ON p.CatId = c.CatId";

                if (catId.HasValue)
                {
                    query += " WHERE p.CatId = @CatId";
                }

                query += " ORDER BY p.ProId DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    if (catId.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@CatId", catId.Value);
                    }

                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            list.Add(new Product
                            {
                                ProId = reader.GetInt32(0),
                                ProName = reader.GetString(1),
                                Price = reader.GetDecimal(2),
                                Discount = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3),
                                CreatedAt = reader.IsDBNull(4) ? null : reader.GetDateTime(4),
                                Img = reader.IsDBNull(5) ? null : reader.GetString(5),
                                CatId = reader.IsDBNull(6) ? null : reader.GetInt32(6),
                                CatName = reader.IsDBNull(7) ? null : reader.GetString(7)
                            });
                        }
                    }
                }
            }
            return list;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            Product? product = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT p.ProId, p.ProName, p.Price, p.Discount, p.CreatedAt, p.Img, p.CatId, c.CatName 
                    FROM product p 
                    LEFT JOIN category c ON p.CatId = c.CatId 
                    WHERE p.ProId = @ProId";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProId", id);
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            product = new Product
                            {
                                ProId = reader.GetInt32(0),
                                ProName = reader.GetString(1),
                                Price = reader.GetDecimal(2),
                                Discount = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3),
                                CreatedAt = reader.IsDBNull(4) ? null : reader.GetDateTime(4),
                                Img = reader.IsDBNull(5) ? null : reader.GetString(5),
                                CatId = reader.IsDBNull(6) ? null : reader.GetInt32(6),
                                CatName = reader.IsDBNull(7) ? null : reader.GetString(7)
                            };
                        }
                    }
                }
            }
            return product;
        }

        public async Task<bool> AddAsync(Product product)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    INSERT INTO product (ProName, Price, Discount, CreatedAt, Img, CatId) 
                    VALUES (@ProName, @Price, @Discount, GETDATE(), @Img, @CatId)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProName", product.ProName);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@Discount", (object?)product.Discount ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Img", (object?)product.Img ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CatId", (object?)product.CatId ?? DBNull.Value);

                    await conn.OpenAsync();
                    int rows = await cmd.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    UPDATE product 
                    SET ProName = @ProName, Price = @Price, Discount = @Discount, Img = @Img, CatId = @CatId 
                    WHERE ProId = @ProId";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProName", product.ProName);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@Discount", (object?)product.Discount ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Img", (object?)product.Img ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CatId", (object?)product.CatId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProId", product.ProId);

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
                string query = "DELETE FROM product WHERE ProId = @ProId";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProId", id);
                    await conn.OpenAsync();
                    int rows = await cmd.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
        }
    }
}