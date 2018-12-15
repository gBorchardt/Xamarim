using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App05_ControleXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WebViewPage : ContentPage
	{
		public WebViewPage ()
		{
			InitializeComponent ();
		}

        private void GoPagina(object sender, EventArgs e)
        {
            Navegador.Source = EnderecoSite.Text;
        }

        private void GoProximo(object sender, EventArgs e)
        {
            if (Navegador.CanGoForward)
                Navegador.GoForward();
        }

        private void GoVoltar(object sender, EventArgs e)
        {
            if (Navegador.CanGoBack)
                Navegador.GoBack();
        }

        private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            lblStatus.Text = "Carregando...";
        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            lblStatus.Text = "Página Carregada";
        }
    }
}