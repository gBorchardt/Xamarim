using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App15_SOAPCliente
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Enviar(object sender, EventArgs e)
        {
            var num1 = int.Parse(Num1.Text);
            var num2 = int.Parse(Num2.Text);

            Resultado.Text = DependencyService.Get<IServiceSOAP>().Somar(num1, num2).ToString();

        }
    }
}
