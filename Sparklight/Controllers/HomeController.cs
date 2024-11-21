using Microsoft.AspNetCore.Mvc;
using Sparklight.Domain.Repositories;
using Sparklight.Models;
using Sparklight.Infrastructure.Repositories;
using System.Diagnostics;

namespace Sparklight.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAparelhoRepository _aparelhoRepository;

        public HomeController(ILogger<HomeController> logger, IAparelhoRepository aparelhoRepository)
        {
            _logger = logger;
            _aparelhoRepository = aparelhoRepository;
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

        public async Task<IActionResult> Dashboard()
        {
            ViewBag.UserName = TempData["UserName"] ?? "Usuário";

            // Busca os aparelhos no banco de dados
            var aparelhos = await _aparelhoRepository.GetAllAsync();
            return View(aparelhos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Registro()
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
