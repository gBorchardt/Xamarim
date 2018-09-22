using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_TipoPagina.TipoPagina.Navigation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Pagina1 : ContentPage
	{
		public Pagina1 ()
		{
			InitializeComponent ();
		}

        private void MudarParaPagina2(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Pagina2());
        }

        private void MudarParaModal(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Modal());
        }

        private void MudarParaMaster(object sender, EventArgs args)
        {
            App.Current.MainPage = new Master.Master();
        }
    }
}