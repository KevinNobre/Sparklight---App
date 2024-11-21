using Microsoft.AspNetCore.Mvc;
using Sparklight.Domain.Entities;
using Sparklight.Services;

namespace Sparklight.Controllers
{
    public class AparelhoController : Controller
    {
        private readonly AparelhoService _aparelhoService;

        public AparelhoController(AparelhoService aparelhoService)
        {
            _aparelhoService = aparelhoService;
        }

        // Listar todos os aparelhos
        public async Task<IActionResult> Index()
        {
            var aparelhos = await _aparelhoService.GetAllAparelhosAsync();
            return View(aparelhos);
        }

        // Exibir detalhes de um aparelho
        public async Task<IActionResult> Details(int id)
        {
            var aparelho = await _aparelhoService.GetAparelhoByIdAsync(id);
            if (aparelho == null)
            {
                return NotFound("Aparelho não encontrado.");
            }
            return View(aparelho);
        }

        // Exibir formulário de criação
        public IActionResult Create()
        {
            return View();
        }

        // Criar um novo aparelho
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Aparelho aparelho)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _aparelhoService.AddAparelhoAsync(aparelho);

                    // Redireciona para Home/Dashboard após o salvamento
                    return RedirectToAction("Dashboard", "Home");
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(aparelho);
        }

        // Exibir formulário de edição
        public async Task<IActionResult> Edit(int id)
        {
            var aparelho = await _aparelhoService.GetAparelhoByIdAsync(id);
            if (aparelho == null)
            {
                return NotFound("Aparelho não encontrado.");
            }
            return View(aparelho);
        }

        // Atualizar um aparelho existente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Aparelho aparelho)
        {
            if (id != aparelho.AparelhoId)
            {
                return BadRequest("IDs não coincidem.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _aparelhoService.UpdateAparelhoAsync(aparelho);
                    return RedirectToAction(nameof(Index));
                }
                catch (KeyNotFoundException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(aparelho);
        }

        // Exibir confirmação de exclusão
        public async Task<IActionResult> Delete(int id)
        {
            var aparelho = await _aparelhoService.GetAparelhoByIdAsync(id);
            if (aparelho == null)
            {
                return NotFound("Aparelho não encontrado.");
            }
            return View(aparelho);
        }

        // Excluir um aparelho
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _aparelhoService.DeleteAparelhoAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        // Buscar aparelhos por nome
        public async Task<IActionResult> Search(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                ModelState.AddModelError(string.Empty, "Por favor, insira um nome válido para buscar.");
                return RedirectToAction(nameof(Index));
            }

            var aparelhos = await _aparelhoService.GetAparelhosByNomeAsync(nome);
            return View("Index", aparelhos);
        }
    }
}
