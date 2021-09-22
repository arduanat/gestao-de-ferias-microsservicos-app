using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Services;

namespace App.Controllers
{
    public class ColaboradorController : Controller
    {
        private readonly ColaboradorService colaboradorService;

        public ColaboradorController(ColaboradorService colaboradorService)
        {
            this.colaboradorService = colaboradorService;
        }

        public async Task<IActionResult> Index()
        {
            var colaboradores = await colaboradorService.Buscar(0);
            return View(colaboradores);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(ColaboradorViewModel colaborador)
        {
            if (ModelState.IsValid)
            {
                await colaboradorService.Criar(colaborador);
                return RedirectToAction(nameof(Index));
            }
            return View(colaborador);
        }

        public async Task<IActionResult> Editar(int id)
        {
            if (id == 0)
                return NotFound();

            var colaborador = await colaboradorService.Buscar(id);

            return View(colaborador.First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(ColaboradorViewModel colaborador)
        {
            if (ModelState.IsValid)
            {
                await colaboradorService.Editar(colaborador);
                return RedirectToAction(nameof(Index));
            }

            return View(colaborador);
        }

        public async Task<IActionResult> Deletar(int id)
        {
            if (id == 0)
                return NotFound();

            await colaboradorService.Deletar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}