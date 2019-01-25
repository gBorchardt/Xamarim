using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App23_DetectarSO
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            if (Device.Idiom == TargetIdiom.Tablet)
                SLContainer.BackgroundColor = Color.Aqua;

            //Opção 1
            if (Device.OS == TargetPlatform.iOS)
                SLContainer.Margin = new Thickness(0, 10, 0, 0);

            //Opção 2
            var margin = new Thickness();
            
            Device.OnPlatform(iOS: () => {
                margin = new Thickness(0, 10, 0, 0);
            }, Android: () => {
            }, WinPhone: () => { });

            SLContainer.Margin = margin;
        }
    }
}
