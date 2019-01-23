using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App21_CustomControl
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MyControl_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Evento","Fui Executado", "OK");
        }
    }
}
