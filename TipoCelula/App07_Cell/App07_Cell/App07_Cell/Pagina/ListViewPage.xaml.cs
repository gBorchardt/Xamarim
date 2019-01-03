using App07_Cell.Modelo;
using App07_Cell.Pagina.Detalhe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App07_Cell.Pagina
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewPage : ContentPage
	{
		public ListViewPage ()
		{
			InitializeComponent ();

            var funcionarios = new List<Funcionario>
            {
                new Funcionario() { Nome = "Gabriel", Cargo = "Desenvolvedor" },
                new Funcionario() { Nome = "Marcos", Cargo = "Analista" },
                new Funcionario() { Nome = "Pedro", Cargo = "Tester" },
                new Funcionario() { Nome = "Paulo Fernando", Cargo = "Suporte" },
                new Funcionario() { Nome = "Kleber", Cargo = "Gerente" }
            };

            ListaFuncionarios.ItemsSource = funcionarios;
        }

        private void ListaFuncionarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var funcionario = (Funcionario)e.SelectedItem;

            Navigation.PushAsync(new DetailPage(funcionario));
        }

        private void MenuItemFerias_Clicked(object sender, EventArgs args)
        {
            var botao = (MenuItem)sender;
            var funcionario = (Funcionario)botao.CommandParameter;

            DisplayAlert("Férias", $"Mensagem:{funcionario.Nome} - {funcionario.Cargo}", "OK");
        }

        private void MenuItemAbono_Clicked(object sender, EventArgs args)
        {
            var botao = (MenuItem)sender;
            var funcionario = (Funcionario)botao.CommandParameter;

            DisplayAlert("Abono", $"Mensagem:{funcionario.Nome} - {funcionario.Cargo}", "OK");
        }
    }
}