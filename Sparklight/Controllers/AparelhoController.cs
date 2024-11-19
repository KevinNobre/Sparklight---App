using Microsoft.AspNetCore.Mvc;
using Sparklight.Domain.Entities;
using Sparklight.Domain.Repositories;

namespace Sparklight.Controllers
{
    public class AparelhoController : Controller
    {
        private readonly IAparelhoRepository _aparelhoRepository;

        public AparelhoController(IAparelhoRepository aparelhoRepository)
        {
            _aparelhoRepository = aparelhoRepository;
        }

        // Listar todos os aparelhos
        public async Task<IActionResult> Index()
        {
            var aparelhos = await _aparelhoRepository.GetAllAsync();
            return View(aparelhos);
        }

        // Exibir detalhes de um aparelho
        public async Task<IActionResult> Details(int id)
        {
            var aparelho = await _aparelhoRepository.GetByIdAsync(id);
            if (aparelho == null)
            {
                return NotFound();
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
                await _aparelhoRepository.AddAsync(aparelho);
                return RedirectToAction(nameof(Index));
            }
            return View(aparelho);
        }

        // Exibir formulário de edição
        public async Task<IActionResult> Edit(int id)
        {
            var aparelho = await _aparelhoRepository.GetByIdAsync(id);
            if (aparelho == null)
            {
                return NotFound();
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
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _aparelhoRepository.UpdateAsync(aparelho);
                return RedirectToAction(nameof(Index));
            }
            return View(aparelho);
        }

        // Exibir confirmação de exclusão
        public async Task<IActionResult> Delete(int id)
        {
            var aparelho = await _aparelhoRepository.GetByIdAsync(id);
            if (aparelho == null)
            {
                return NotFound();
            }
            return View(aparelho);
        }

        // Excluir um aparelho
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _aparelhoRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
