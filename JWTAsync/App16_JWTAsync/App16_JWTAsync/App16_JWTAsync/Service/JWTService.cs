using App16_JWTAsync.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App16_JWTAsync.Service
{
    public class JWTService
    {
        private static string BaseURL = "http://ws.spacedu.com.br/xf2018/rest/apix";
        private static string _token;
        private static string _tokenType;

        public async static Task<string> GetToken(string nome, string password)
        {
            var url = BaseURL + "/token";

            var parameters = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("nome", nome),
                new KeyValuePair<string, string>("password", password)
            });

            var request = new HttpClient();
            var response = await request.PostAsync(url, parameters);

            if(response.StatusCode == HttpStatusCode.OK)
            {
                var respostaToken = JsonConvert.DeserializeObject<RespostaToken>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                _tokenType = respostaToken.token_type;
                _token = respostaToken.acess_token;
                return _tokenType + " " + _token;
            }
            else
            {
                return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }

        public async static Task<string> Verificar()
        {
            var url = BaseURL + "/verify";

            var request = new HttpClient();
                        
            request.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( _tokenType, _token);
            var response = await request.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var respostaVerificar = JsonConvert.DeserializeObject<RespostaVerificar>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                return respostaVerificar.usuario.id + " - " + respostaVerificar.usuario.nome;
            }
            else
            {
                return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }
    }
}
