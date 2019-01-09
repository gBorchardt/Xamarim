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
	public partial class VagasCadastradas : ContentPage
	{
        private readonly Database _database;
        private List<Vaga> _listaVagas;

        public VagasCadastradas ()
		{
            InitializeComponent();

            _database = new Database();

            ListarVagas();
        }

        private void EditarAction(object sender, EventArgs e)
        {
            var lblEditar = (Label)sender;
            var tapGestureRecognizer = (TapGestureRecognizer)lblEditar.GestureRecognizers[0];
            var vaga = (Vaga)tapGestureRecognizer.CommandParameter;

            Navigation.PushAsync(new CadastrarVaga(vaga));
        }

        private void ExcluirAction(object sender, EventArgs e)
        {
            var lblExcluir = (Label)sender;
            var tapGestureRecognizer = (TapGestureRecognizer)lblExcluir.GestureRecognizers[0];
            var vaga = (Vaga)tapGestureRecognizer.CommandParameter;
            
            _database.Excluir(vaga);

            App.Current.MainPage = new NavigationPage(new ConsultarVagas());
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