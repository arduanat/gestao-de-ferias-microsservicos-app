using Api;
using App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services
{
    public class ColaboradorService : ConsumirApi
    {
        private readonly Uri uri = new Uri("https://gestao-de-ferias-api-colaborador.azurewebsites.net/Colaborador");

        public async Task<List<Colaborador>> Buscar()
        {
            var rota = "/ObterColaboradores";
            var colaboradores = await Buscar<List<Colaborador>>(uri, rota, RestSharp.Method.GET);
            return colaboradores;
        }

        public async Task<Response> Criar(int quantidade)
        {
            var rota = "/CriarColaboradores";
            var resposta = await Enviar<Response>(uri, rota, RestSharp.Method.POST, quantidade);
            return resposta;
        }
           
        public async Task<Response> LimparBanco()
        {
            var rota = "/LimparBanco";
            var resposta = await Enviar<Response>(uri, rota, RestSharp.Method.DELETE, null);
            return resposta;
        }
    }
}