using Api;
using App.Models;
using System;
using System.Threading.Tasks;

namespace App.Services
{
    public class HomologacaoDeFeriasService : ConsumirApi
    {
        private readonly Uri uri = new Uri("https://gestao-de-ferias-api-homologacao.azurewebsites.net");
        private readonly string rota = "/homologacao";
        public async Task<HomologacaoDeFeriasViewModel> Buscar(int feriasId)
        {
            var homologacaoDeFerias = await Buscar<HomologacaoDeFeriasViewModel>(uri, $"{rota}/{feriasId}", RestSharp.Method.GET);
            return homologacaoDeFerias;
        }

        public async Task<Response> Criar(HomologacaoDeFeriasViewModel homologacao)
        {
            var resposta = await Enviar<Response>(uri, rota, RestSharp.Method.POST, homologacao);
            return resposta;
        }
    }
}
