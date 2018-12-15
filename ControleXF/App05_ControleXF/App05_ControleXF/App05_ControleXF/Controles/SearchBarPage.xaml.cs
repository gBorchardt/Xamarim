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
	public partial class SearchBarPage : ContentPage
	{
        private List<string> empresasTI;


        public SearchBarPage()
		{
			InitializeComponent();

            empresasTI = new List<string>();
            empresasTI.Add("Microsoft");
            empresasTI.Add("Apple");
            empresasTI.Add("Oracle");
            empresasTI.Add("SAP");
            empresasTI.Add("Uber");

            Preencher(empresasTI);

        }

        private void Preencher(List<string> empresasTI)
        {
            ListResult.Children.Clear();
            foreach (var empresa in empresasTI)
            {
                ListResult.Children.Add(new Label { Text = empresa });
            }
        }

        private void Pesquisar(object sender, TextChangedEventArgs args)
        {
            var resutado = empresasTI.Where(x => x.Contains(args.NewTextValue)).ToList();

            Preencher(resutado);
        }

        private void PesquisarButton(object sender, EventArgs args)
        {
            var resutado = empresasTI.Where(x => x.Contains(((SearchBar)sender).Text)).ToList();

            Preencher(resutado);
        }
    }
}