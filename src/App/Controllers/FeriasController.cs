using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class FeriasController : Controller
    {
        private readonly ColaboradorService colaboradorService;
        private readonly FeriasService feriasService;
        private readonly HomologacaoDeFeriasService homologacaoService;

        public FeriasController(ColaboradorService colaboradorService, FeriasService feriasService, HomologacaoDeFeriasService homologacaoService)
        {
            this.colaboradorService = colaboradorService;
            this.feriasService = feriasService;
            this.homologacaoService = homologacaoService;
        }

        public async Task<IActionResult> CriarParaMultiplosColaboradores(List<int> idsDosColaboradores, List<PeriodoDeFeriasViewModel> periodos)
        {
            List<FeriasViewModel> feriasDosColaboradores = new List<FeriasViewModel>();

            var colaboradores = await colaboradorService.Buscar();

            var periodosDeFerias = periodos.Select(x => new PeriodoDeFeriasViewModel()).ToList();

            foreach (var colaborador in colaboradores)
            {
                var feriasViewModel = new FeriasViewModel();
                await feriasService.Criar(feriasViewModel);
            }

            return RedirectToAction("Index", "Colaborador");
        }

        public async Task<IActionResult> MapaDeFerias()
        {
            var ferias = await feriasService.Buscar();

            return View(ferias);
        }

        public async Task<IActionResult> HomologarMultiplasFerias(List<int> feriasIds, string situacao)
        {
            foreach (var id in feriasIds)
            {
                var homologacao = new HomologacaoDeFeriasViewModel();
                await homologacaoService.Criar(homologacao);
            }

            return RedirectToAction(nameof(MapaDeFerias));
        }
    }
}