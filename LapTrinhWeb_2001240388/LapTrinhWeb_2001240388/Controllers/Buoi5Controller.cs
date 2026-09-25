using LapTrinhWeb_2001240388.Models.Buoi3_4_5;
using LapTrinhWeb_2001240388.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LapTrinhWeb_2001240388.Controllers
{
    public class Buoi5Controller : Controller
    {
        private readonly string _connection;
        private readonly EmailService _emailService;
        public Buoi5Controller(IConfiguration configuration, EmailService emailService)
        {
            _connection = configuration.GetConnectionString("DefaultConnection");
            _emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            List<Sach> dsSach = new List<Sach>();

            using (var connection = new SqlConnection(_connection))
            {
                await connection.OpenAsync();
                var querySach = "SELECT TOP 3 * FROM Sach WHERE Moi = 1 ORDER BY NEWID()";
                using (var cmd = new SqlCommand(querySach, connection))
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        dsSach.Add(new Sach
                        {
                            MaSach = Convert.ToInt32(reader["MaSach"]),
                            TenSach = reader["TenSach"].ToString(),
                            AnhBia = reader["AnhBia"].ToString(),
                            GiaBan = Convert.ToDouble(reader["GiaBan"])
                        });
                    }
                }
            }

            return View(dsSach);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string tenSach)
        {
            List<Sach> dsSach = new List<Sach>();

            if (string.IsNullOrWhiteSpace(tenSach))
            {
                return RedirectToAction(nameof(Index));
            }

            using (var connection = new SqlConnection(_connection))
            {
                await connection.OpenAsync();
                var querySach = "SELECT * FROM Sach WHERE TenSach LIKE @tenSach";
                using (var cmd = new SqlCommand(querySach, connection))
                {
                    cmd.Parameters.AddWithValue("@tenSach", $"%{tenSach}%");

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            dsSach.Add(new Sach
                            {
                                MaSach = Convert.ToInt32(reader["MaSach"]),
                                TenSach = reader["TenSach"].ToString(),
                                AnhBia = reader["AnhBia"].ToString(),
                                GiaBan = Convert.ToDouble(reader["GiaBan"])
                            });
                        }
                    }
                }
            }
            return View("Index", dsSach);
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(string email, string thongTin)
        {
            ViewBag.Email = email;
            ViewBag.ThongTin = thongTin;

            try
            {
                string subject = "Xác nhận thông tin liên hệ từ Book Library";
                string message = $"Chào bạn,\n\nChúng tôi đã nhận được thông tin liên hệ của bạn với nội dung như sau:\n\n- Email: {email}\n- Thông tin: {thongTin}\n\nCảm ơn bạn đã liên hệ!";

                await _emailService.SendEmailAsync(email, subject, message);

                ViewBag.TrangThaiGui = "Đã gửi email xác nhận thành công đến " + email;
            }
            catch (Exception ex)
            {
                ViewBag.TrangThaiGui = "Lỗi khi gửi email: " + ex.Message;
            }

            return View();
        }
    }
}

