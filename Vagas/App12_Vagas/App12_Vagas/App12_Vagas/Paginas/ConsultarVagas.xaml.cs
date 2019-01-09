using App12_Vagas.Banco;
using App12_Vagas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App12_Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConsultarVagas : ContentPage
	{
        private readonly Database _database;
        private List<Vaga> _listaVagas;

		public ConsultarVagas ()
		{
			InitializeComponent ();

            _database = new Database();

            ListarVagas();
        }

        private void GoCadastro(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastrarVaga());
        }

        private void GoMinhasVagas(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VagasCadastradas());

        }

        private void MaisDetalhesAction(object sender, EventArgs e)
        {
            var lblDetalheVaga = (Label)sender;
            var tapGestureRecognizer = (TapGestureRecognizer)lblDetalheVaga.GestureRecognizers[0];
            var vaga = (Vaga)tapGestureRecognizer.CommandParameter;

            Navigation.PushAsync(new DetalheVaga(vaga));
        }

        private void PesquisarAction(object sender, TextChangedEventArgs e)
        {
            ListarVagas(e.NewTextValue);
        }

        private void ListarVagas(string palavra = "")
        {
            _listaVagas = _database.Listar(palavra);
            ListaVagas.ItemsSource = _listaVagas;
            lblQtdTotal.Text = _listaVagas.Count().ToString() + " Vaga(s) Cadastrada(s).";
        }
    }
}