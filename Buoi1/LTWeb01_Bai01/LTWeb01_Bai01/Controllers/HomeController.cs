using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb01_Bai01.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? id)
        {
            return Content($"ID: {id}");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult Index3(int id, string name)
        {
            ViewBag.Id = id;
            ViewData["Name"] = name;
            return View();
        }
    }
}