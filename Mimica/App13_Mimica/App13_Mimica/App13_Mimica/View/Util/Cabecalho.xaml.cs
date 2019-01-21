using App13_Mimica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App13_Mimica.View.Util
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cabecalho : ContentView
	{
		public Cabecalho ()
		{
			InitializeComponent ();

            BindingContext = new CabecalhoViewModel();
        }

        private void ReiniciarEvento(object sender, EventArgs e)
        {
            var viewModel = (CabecalhoViewModel)this.BindingContext;

            if (viewModel.ReiniciarCommand.CanExecute(null))
                viewModel.ReiniciarCommand.Execute(null);
        }
    }
}