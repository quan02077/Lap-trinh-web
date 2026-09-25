using LapTrinhWeb_2001240388.Models.Buoi3_4_5;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LapTrinhWeb_2001240388.ViewComponents
{
    public class ChuDeMenuViewComponent: ViewComponent
    {
        private readonly string _connection;

        public ChuDeMenuViewComponent(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var chuDe = new List<ChuDe>();

            using (var connection = new SqlConnection(_connection))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM ChuDe";
                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        chuDe.Add(new ChuDe
                        {
                            MaChuDe = Convert.ToInt32(reader["MaChuDe"]),
                            TenChuDe = reader["TenChuDe"].ToString()
                        });
                    }
                }
            }

            return View(chuDe);
        }
    }
}
