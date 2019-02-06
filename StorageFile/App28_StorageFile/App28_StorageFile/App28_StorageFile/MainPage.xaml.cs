using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App28_StorageFile
{
    public partial class MainPage : ContentPage
    {
        const string filename = "file.txt";

        public MainPage()
        {
            InitializeComponent();

            btnEscrever.Clicked += async (sender, args) =>
            {
                Util.StorageManager.SalvarConteudo(filename, txtConteudo.Text);
                txtConteudo.Text = string.Empty;
            };

            btnLer.Clicked += async (sender, args) =>
            {
                lblLeitura.Text = await Util.StorageManager.LerConteudo(filename);
            };
        }
    }
}
