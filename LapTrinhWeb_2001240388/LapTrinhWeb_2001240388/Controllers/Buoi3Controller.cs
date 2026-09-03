using LapTrinhWeb_2001240388.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LapTrinhWeb_2001240388.Controllers
{
    public class Buoi3Controller : Controller
    {
        private readonly BookstoreContext _context;

        public Buoi3Controller(BookstoreContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _context.Saches.Include(b => b.MaChuDeNavigation).Include(b => b.MaNxbNavigation).ToListAsync();
            return View(books);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var book = await _context.Saches.Include(b => b.MaChuDeNavigation).Include(b => b.MaNxbNavigation).FirstOrDefaultAsync(b => b.MaSach == id);
            return View(book);
        }
        public IActionResult GetCategory(int id)
        {

            var books = _context.ChuDes.Where(b => b.MaChuDe == id).ToList();
            return View();
        }
    }
}
