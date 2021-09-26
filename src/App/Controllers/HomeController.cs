using App.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ColaboradorService colaboradorService;
        private readonly FeriasService feriasService;

        public HomeController(ColaboradorService colaboradorService, FeriasService feriasService)
        {
            this.colaboradorService = colaboradorService;
            this.feriasService = feriasService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> LimparBanco()
        {
            await colaboradorService.LimparBanco();
            await feriasService.LimparBanco();
            return RedirectToAction(nameof(Index));
        }
    }
}