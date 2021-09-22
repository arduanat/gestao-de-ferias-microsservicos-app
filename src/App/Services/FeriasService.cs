using Api;
using App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services
{
    public class FeriasService : ConsumirApi
    {
        private readonly Uri uri = new Uri("https://gestao-de-ferias-api-ferias.azurewebsites.net");
        private readonly string rota = "/ferias";

        public async Task<List<FeriasViewModel>> Buscar(int colaboradorId = 0)
        {
            
            var ferias = await Buscar<List<FeriasViewModel>>(uri, $"{rota}/{colaboradorId}", RestSharp.Method.GET);
            return ferias;
        }

        public async Task<Response> Criar(FeriasViewModel ferias)
        {
            var resposta = await Enviar<Response>(uri, rota, RestSharp.Method.POST, ferias);
            return resposta;
        }
    }
}
