using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App20_CustomRenderer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var btn = new Button
            {
                Text = "Eu Sou Diferente",
                TextColor = Color.Coral
            };

            SLContainer.Children.Add(btn);
        }
    }
}
