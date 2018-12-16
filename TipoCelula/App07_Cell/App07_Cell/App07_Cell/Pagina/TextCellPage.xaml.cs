using App07_Cell.Modelo;
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
	public partial class TextCellPage : ContentPage
	{
		public TextCellPage ()
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
	}
}