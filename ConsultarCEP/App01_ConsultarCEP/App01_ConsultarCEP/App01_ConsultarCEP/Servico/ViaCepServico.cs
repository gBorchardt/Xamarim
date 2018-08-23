using App01_ConsultarCEP.Modelo;
using Newtonsoft.Json;
using System.Net;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCepServico
    {
        private static readonly string enderecoUrl = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEndecoViaCep(string cep)
        {
            var novoEnderecoUrl = string.Format(enderecoUrl, cep);

            var webCliente = new WebClient();

            var conteudo = webCliente.DownloadString(novoEnderecoUrl);

            var endereco = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (endereco.cep == null)
                return null;

            return endereco;
        }
    }
}
