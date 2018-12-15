using App05_ControleXF.Modelos;
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
	public partial class ListViewPage : ContentPage
	{
		public ListViewPage()
		{
			InitializeComponent();

            var pessoas = new List<Pessoa>
            {
                new Pessoa { Nome = "Gabriel", Idade = 26 },
                new Pessoa { Nome = "Shaiane", Idade = 29 },
                new Pessoa { Nome = "João", Idade = 35 },
                new Pessoa { Nome = "Paulo", Idade = 57 },
                new Pessoa { Nome = "Maria", Idade = 89 }
            };

            ListaPessoas.ItemsSource = pessoas;
        }
	}
}