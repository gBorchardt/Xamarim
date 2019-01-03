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
	public partial class CidadesPage : ContentPage
	{
        private List<Cidade> _cidades { get; set; }

        public CidadesPage(Estado estado)
		{
			InitializeComponent ();

            _cidades = Servico.BuscaServico.GetCidades(estado.Id);

            ListaCidades.ItemsSource = _cidades;
		}

        private void TxtCidade_TextChanged(object sender, TextChangedEventArgs args)
        {
            var cidade = args.NewTextValue;
            ListaCidades.ItemsSource = _cidades.Where(x => x.Nome.ToUpper().Contains(cidade.ToUpper()));
        }
    }
}