using DemoMyApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoMyApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }

        // url: /Home/Chao
        public IActionResult Chao(string ten = "Admin")
        {
            return Content($"Xin chào bạn {ten}");
        }

        // url: /Home/XoSo
        public int XoSo()
        {
            return new Random().Next(1000, 10000);
        }

        // host/Home/Niie
        public IActionResult Niie()
        {
            return Json(new
            {
                Name = "NIIE",
                Age = 2015,
                President = "Dr. Anh Tuan Nguyen"
            });
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
