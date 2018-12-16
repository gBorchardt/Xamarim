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
	public partial class ImageCellPage : ContentPage
	{
		public ImageCellPage ()
		{
			InitializeComponent ();

            var funcionarios = new List<Funcionario>
            {
                new Funcionario() { Foto = "perfil.png", Nome = "Gabriel", Cargo = "Desenvolvedor"},
                new Funcionario() { Foto = "perfil.png", Nome = "Marcos", Cargo = "Analista" },
                new Funcionario() { Foto = "perfil.png", Nome = "Pedro", Cargo = "Tester" },
                new Funcionario() { Foto = "perfil.png", Nome = "Paulo Fernando", Cargo = "Suporte" },
                new Funcionario() { Foto = "perfil.png", Nome = "Kleber", Cargo = "Gerente" }
            };

            ListaFuncionarios.ItemsSource = funcionarios;
        }
	}
}