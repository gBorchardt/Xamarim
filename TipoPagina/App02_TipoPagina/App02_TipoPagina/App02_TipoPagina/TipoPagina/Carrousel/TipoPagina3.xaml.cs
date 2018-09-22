using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_TipoPagina.TipoPagina.Carrousel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TipoPagina3 : ContentPage
	{
		public TipoPagina3 ()
		{
			InitializeComponent ();
		}

        private void MudarPagina(Object sender, EventArgs args)
        {
            //Navigation
            //App.Current.MainPage = new NavigationPage(new Navigation.Pagina1()) { BackgroundColor = Color.Blue };

            //Tabbed
            App.Current.MainPage = new Tabbed.Abas();
        }
    }
}