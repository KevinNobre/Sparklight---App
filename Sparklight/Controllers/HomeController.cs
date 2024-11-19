using Microsoft.AspNetCore.Mvc;
using Sparklight.Models;
using System.Diagnostics;

namespace Sparklight.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            
            if (Email == "admin@sparklight.com" && Password == "123456")
            {
                TempData["UserName"] = "Admin"; 
                return RedirectToAction("Dashboard");
            }

            // Caso as credenciais sejam inválidas
            ViewBag.ErrorMessage = "Credenciais inválidas. Tente novamente.";
            return View("Index");
        }

        public IActionResult Dashboard()
        {
            ViewBag.UserName = TempData["UserName"] ?? "Usuário";
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
