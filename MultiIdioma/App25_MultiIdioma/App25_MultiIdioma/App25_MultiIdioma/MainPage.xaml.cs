using App25_MultiIdioma.Traducao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App25_MultiIdioma
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Lang.AppLang.Culture = DependencyService.Get<ILocale>().GetCurrentCultureInfo();
            lblMsg.Text = Lang.AppLang.MSG_01;
        }
    }
}
