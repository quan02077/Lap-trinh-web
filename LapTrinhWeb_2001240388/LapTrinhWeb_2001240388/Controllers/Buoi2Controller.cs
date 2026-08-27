using LapTrinhWeb_2001240388.Models.Buoi2;
using Microsoft.AspNetCore.Mvc;

namespace LapTrinhWeb_2001240388.Controllers
{
    public class Buoi2Controller : Controller
    {
        static public List<SanPham> Ds_SanPham = new List<SanPham>() 
        { 
            new SanPham() { Id = 1, Name = "Laptop Dell", Price = 1500, img = "/hinhAnh/dell.jpg" },
            new SanPham() { Id = 2, Name = "Laptop HP", Price = 1200, img = "/hinhAnh/hp.png" },
            new SanPham() { Id = 3, Name = "Laptop Asus", Price = 1400, img = "/hinhAnh/asus.jpg" },
        };
        public IActionResult DisplayAll()
        {
            return View(Ds_SanPham);
        }

        public IActionResult GetByID(int id)
        {
            var sanPham = Ds_SanPham.FirstOrDefault(sp => sp.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }
            return View(sanPham);
        }
    }
}
