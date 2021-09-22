using Api;
using App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services
{
    public class ColaboradorService : ConsumirApi
    {
        private readonly Uri uri = new Uri("https://gestao-de-ferias-api-colaborador.azurewebsites.net/colaborador");
        private readonly string rota = "/colaborador";

        public async Task<List<ColaboradorViewModel>> Buscar(int id = 0)
        {
            var colaboradores = await Buscar<List<ColaboradorViewModel>>(uri, $"{rota}/{id}", RestSharp.Method.GET);
            return colaboradores;
        }

        public async Task<Response> Criar(ColaboradorViewModel colaborador)
        {
            var resposta = await Enviar<Response>(uri, rota, RestSharp.Method.POST, colaborador);
            return resposta;
        }
        
        public async Task<Response> Editar(ColaboradorViewModel colaborador)
        {
            var resposta = await Enviar<Response>(uri, rota, RestSharp.Method.PUT, colaborador);
            return resposta;
        }
        
        public async Task<Response> Deletar(int id)
        {
            var resposta = await Enviar<Response>(uri, rota, RestSharp.Method.DELETE, id);
            return resposta;
        }
    }
}
