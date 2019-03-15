using Xamarin.Forms;

namespace App32_LoginSocial.Views
{
    public partial class Inicial : ContentPage
    {
        public Inicial(params string[] parametros)
        {
            InitializeComponent();

            foreach (var parametro in parametros)
            {
                lblInformacao.Text = parametro + "\n";
            }
        }
    }
}
