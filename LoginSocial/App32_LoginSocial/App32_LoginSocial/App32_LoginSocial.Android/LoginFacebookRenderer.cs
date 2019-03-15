using Android.App;
using Android.Content;
using App32_LoginSocial.Droid;
using App32_LoginSocial.Views;
using System;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LoginFacebook), typeof(LoginFacebookRenderer))]
namespace App32_LoginSocial.Droid
{
    public class LoginFacebookRenderer : PageRenderer
    {
        public LoginFacebookRenderer(Context context) : base(context)
        {
            //https://github.com/xamarin/Xamarin.Auth
            //Usando OAuth(Xamarin.Auth)

            //Scope: https://developers.facebook.com/docs/facebook-login/manually-build-a-login-flow?locale=pt_BR
            //       https://developers.facebook.com/docs/facebook-login/permissions/

            var oAuth = new OAuth2Authenticator(
                    clientId: "591863861224875",
                    scope: "email",
                    authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                    redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html")
                );

            oAuth.Completed += async (sender, args) =>
            {
                if (args.IsAuthenticated)
                {
                    //Acesso aos dados - Token de Acesso
                    var token = args.Account.Properties["access_token"];

                    //https://developers.facebook.com/docs/graph-api/
                    //https://developers.facebook.com/tools/explorer

                    var resquest = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me?fields=name,email"), null, args.Account);
                    var response = await resquest.GetResponseAsync();

                    //dynamic login = JsonConvert.DeserializeObject(response.GetResponseText());
                    //var nome = obj.name.ToString();
                    //var email = obj.email.ToString();

                    var obj = Newtonsoft.Json.Linq.JObject.Parse(response.GetResponseText());
                    var nome = obj["name"].ToString().Replace("\"","");
                    var email = obj["email"].ToString().Replace("\"", "");

                    App.NavegarParaInicial(nome, email);
                }
                else
                {
                    App.NavegarParaInicial("Login rejeitado");
                }
            };

            //API do Android - Xamarin.Android
            var activity = this.Context as Activity;

            activity.StartActivity(oAuth.GetUI(activity));
        }
    }
}