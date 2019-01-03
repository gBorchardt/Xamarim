using App09_ListaEstados.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App09_ListaEstados.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EstadosPage : ContentPage
	{
		public EstadosPage ()
		{
			InitializeComponent ();

            ListaEstados.ItemsSource = Servico.BuscaServico.GetEstados();
		}

        private void ListaEstados_ItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var estado = (Estado)args.SelectedItem;

            Navigation.PushAsync(new CidadesPage(estado));
        }
    }
}