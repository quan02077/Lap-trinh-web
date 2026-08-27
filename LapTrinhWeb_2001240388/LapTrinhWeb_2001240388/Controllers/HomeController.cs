using LapTrinhWeb_2001240388.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LapTrinhWeb_2001240388.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
