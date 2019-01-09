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
	public partial class DetalheVaga : ContentPage
	{
		public DetalheVaga (Vaga vaga)
		{
			InitializeComponent ();

            BindingContext = vaga;

        }
	}
}