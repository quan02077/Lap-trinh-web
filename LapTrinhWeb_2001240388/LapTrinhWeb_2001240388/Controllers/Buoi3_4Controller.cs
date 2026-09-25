using LapTrinhWeb_2001240388.Models.Buoi3_4_5;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LapTrinhWeb_2001240388.Controllers
{
    public class Buoi3_4Controller : Controller
    {
        private readonly string _connectionString;
        public Buoi3_4Controller(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<IActionResult> Index()
        {
            var data = new List<ChuDe>();
            using(var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT * FROM ChuDe", connection);
                using(var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        data.Add(new ChuDe
                        {
                            MaChuDe = reader.GetInt32(0),
                            TenChuDe = reader.GetString(1)
                        });
                    }
                }
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ChuDe chuDe)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "INSERT INTO ChuDe(TenChuDe) VALUES (@TenChuDe)";
                using(var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenChuDe", chuDe.TenChuDe);

                    command.ExecuteNonQuery();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ChuDe chude = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM ChuDe WHERE MaChuDe = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        while(await reader.ReadAsync())
                        {
                            chude = new ChuDe
                            {
                                MaChuDe = reader.GetInt32(0),
                                TenChuDe = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            if (chude == null) return NotFound();
            return View(chude);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ChuDe chuDe)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "UPDATE ChuDe SET TenChuDe = @TenChuDe WHERE MaChuDe = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenChuDe", chuDe.TenChuDe);
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "DELETE FROM ChuDe WHERE MaChuDe = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
