using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App31_FontesPersonalizadas
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //Buscar Fontes: www.urbanfonts.com
            //Extensão .ttf
            //Android - Colar na pasta Assets
            //IOS - Colar na pasta Resource E Criar Font no Info.plist

            lblInicio.FontFamily = Device.OnPlatform(
                                        "Lily of  the Valley_Personal_Use",
                                        "LilyoftheValley.ttf#Lily of  the Valley_Personal_Use",
                                        "Assets/Fonts/LilyoftheValley.ttf#Lily of  the Valley_Personal_Use"
                                    );
        }
    }
}
