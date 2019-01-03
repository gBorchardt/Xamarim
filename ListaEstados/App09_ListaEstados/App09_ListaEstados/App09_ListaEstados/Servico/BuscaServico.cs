using App09_ListaEstados.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace App09_ListaEstados.Servico
{
    public class BuscaServico
    {
        private static string _urlEstado = "https://servicodados.ibge.gov.br/api/v1/localidades/estados";
        private static string _urlCidade = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/{0}/municipios";

        public static List<Estado> GetEstados()
        {
            var webCliente = new WebClient();
            var conteudo = webCliente.DownloadString(_urlEstado);

            return JsonConvert.DeserializeObject<List<Estado>>(conteudo);
        }

        public static List<Cidade> GetCidades(int idEstado)
        {
            string urlCidadeEstado = string.Format(_urlCidade, idEstado);

            var webCliente = new WebClient();
            var conteudo = webCliente.DownloadString(urlCidadeEstado);

            return JsonConvert.DeserializeObject<List<Cidade>>(conteudo);
        }
    }
}
