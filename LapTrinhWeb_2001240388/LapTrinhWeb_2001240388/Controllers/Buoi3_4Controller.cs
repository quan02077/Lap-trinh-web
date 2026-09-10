using LapTrinhWeb_2001240388.Models.Buoi3_4;
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
        public IActionResult Index()
        {
            var data = new List<ChuDe>();
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM ChuDe", connection);
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
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
    }
}
