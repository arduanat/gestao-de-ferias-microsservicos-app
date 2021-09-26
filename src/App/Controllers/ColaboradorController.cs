using System.Threading.Tasks;
using App.Services;
using Microsoft.AspNetCore.Mvc;

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
            var colaboradores = await colaboradorService.Buscar();
            return View(colaboradores);
        }

        public async Task<IActionResult> Criar(int quantidade = 0)
        {
            await colaboradorService.Criar(quantidade);
            return RedirectToAction(nameof(Index));
        }
    }
}