using App14_Chat.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App14_Chat.Service
{
    public class ServiceWS
    {
        private static string urlBase = "http://ws.spacedu.com.br/xf2018/rest/api";

        public async static Task<Usuario> GetUsuario(Usuario usuario)
        {
            var url = urlBase + "/usuario";

            /* Explicativo:
            //QueryString: ?foo="X"&bar="Y"
            //var parameters = new StringContent(string.Format("?nome={0}&password={1}",usuario.nome,usuario.password));
            */

            var parameters = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("nome",usuario.nome),
                new KeyValuePair<string,string>("password",usuario.password),
            });

            var request = new HttpClient();

            var response = await request.PostAsync(url, parameters);//.GetAwaiter().GetResult();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var conteudo = await response.Content.ReadAsStringAsync();//.GetAwaiter().GetResult();

                if (conteudo != null)
                    if (conteudo.Length > 2)
                        return JsonConvert.DeserializeObject<Usuario>(conteudo);

            }

            return null;
        }

        public async static Task<List<Chat>> GetChats()
        {
            var url = urlBase + "/chats";

            var request = new HttpClient();
            var response = await request.GetAsync(url);//.GetAwaiter().GetResult();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {   
                var conteudo = await response.Content.ReadAsStringAsync();//.GetAwaiter().GetResult();

                if (conteudo.Length > 2)
                    return JsonConvert.DeserializeObject<List<Chat>>(conteudo);
            }
            else
            {
                throw new Exception("Código de erro HTTP: " + response.StatusCode);
            }

            return null;
        }

        public async static Task<bool> PostChat(Chat chat)
        {
            var url = urlBase + "/chat";

            var parameters = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("nome",chat.nome),
            });

            var request = new HttpClient();
            var response = await request.PostAsync(url, parameters);//.GetAwaiter().GetResult();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;

            }

            return false;
        }

        public static bool PutChat(Chat chat)
        {
            var url = urlBase + "/chat/" + chat.id;

            var parameters = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("nome",chat.nome),
            });

            var request = new HttpClient();
            var response = request.PutAsync(url, parameters).GetAwaiter().GetResult();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;

            }

            return false;
        }

        public static bool DeleteChat(Chat chat)
        {
            var url = urlBase + "/chat/delete/" + chat.id;

            var request = new HttpClient();
            var response = request.DeleteAsync(url).GetAwaiter().GetResult();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;

            }

            return false;
        }

        public async static Task<List<Mensagem>> GetMensagens(Chat chat)
        {
            var url = urlBase + "/chat/" + chat.id + "/msg";

            var request = new HttpClient();
            var response = await request.GetAsync(url);//.GetAwaiter().GetResult();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var conteudo = await response.Content.ReadAsStringAsync();//.GetAwaiter().GetResult();

                if (conteudo.Length > 2)
                    return JsonConvert.DeserializeObject<List<Mensagem>>(conteudo);
            }
            else
            {
                throw new Exception("Código de erro HTTP: " + response.StatusCode);
            }

            return null;
        }

        public static bool PostMensagem(Mensagem mensagem)
        {
            var url = urlBase + "/chat/" + mensagem.id_chat + "/msg";

            var parameters = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("mensagem",mensagem.mensagem),
                new KeyValuePair<string,string>("id_usuario",mensagem.id_usuario.ToString()),
            });

            var request = new HttpClient();
            var response = request.PostAsync(url, parameters).GetAwaiter().GetResult();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;

            }

            return false;
        }

        public static bool DeleteMensagem(Mensagem mensagem)
        {
            var url = urlBase + "/chat/" + mensagem.id_chat + "/delete/" + mensagem.id;

            var request = new HttpClient();
            var response = request.DeleteAsync(url).GetAwaiter().GetResult();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;

            }

            return false;
        }
    }
}
