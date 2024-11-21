using Microsoft.AspNetCore.Mvc;

public class DashboardController : Controller
{
    public IActionResult Dashboard()
    {
        var dashboardViewModel = new DashboardViewModel
        {
            ValorFatura = 90.00m,
            Economia = 72.59m,
            DataVencimento = new DateTime(2023, 12, 10), 
            TotalKwh = 1115,
            DiferencaTotalKwh = 149,
            PercentualTotalKwh = 9.14,
            TotalAparelhos = 4,
            KwhHoje = 1826,
            DiferencaKwhHoje = 187,
            PercentualKwhHoje = 24.87
        };

        // Verifique se o modelo foi inicializado corretamente
        if (dashboardViewModel == null)
        {
            return View("Error");  // Exiba uma página de erro caso o modelo não seja inicializado
        }

        return View(dashboardViewModel);
    }
}
