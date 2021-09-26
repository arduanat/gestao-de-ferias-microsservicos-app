using Api;
using App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services
{
    public class FeriasService : ConsumirApi
    {
        private readonly Uri uri = new Uri("https://api-gestao-de-ferias-ferias.azurewebsites.net/");

        public async Task<List<Ferias>> Buscar()
        {
            var rota = "/ObterFerias";
            var ferias = await Buscar<List<Ferias>>(uri, rota, RestSharp.Method.GET);
            return ferias;
        }

        public async Task<Response> MarcarFerias(List<PeriodoDeFerias> periodosDeFerias)
        {
            var rota = "/MarcarFerias";
            var resposta = await Enviar<Response>(uri, rota, RestSharp.Method.POST, periodosDeFerias);
            return resposta;
        }

        public async Task<Response> AprovarFerias()
        {
            var rota = "/AprovarFerias";
            var resposta = await Enviar<Response>(uri, rota, RestSharp.Method.POST, null);
            return resposta;
        }

        public async Task LimparBanco()
        {
            var rota = "/LimparBanco";
            await Enviar<Response>(uri, rota, RestSharp.Method.DELETE, null);
        }
    }
}
