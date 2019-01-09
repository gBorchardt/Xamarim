using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App12_Vagas.Banco;
using App12_Vagas.Droid.Banco;
using Xamarin.Forms;

[assembly:Dependency(typeof(Caminho))]
namespace App12_Vagas.Droid.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBancoDados)
        {
            var folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var caminhoBD = Path.Combine(folder,NomeArquivoBancoDados);

            return caminhoBD;
        }
    }
}