using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class FeriasController : Controller
    {
        private readonly FeriasService feriasService;
        public FeriasController(FeriasService feriasService)
        {
            this.feriasService = feriasService;
        }

        public async Task<IActionResult> Index()
        {
            var ferias = await feriasService.Buscar();
            return View(ferias);
        }

        public async Task<IActionResult> Cadastrar(List<PeriodoDeFerias> periodos)
        {
            await feriasService.MarcarFerias(periodos);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Aprovar()
        {
            await feriasService.AprovarFerias();
            return RedirectToAction(nameof(MapaDeFerias));
        }

        public async Task<IActionResult> MapaDeFerias()
        {
            var ferias = await feriasService.Buscar();
            return View(ferias);
        }
    }
}