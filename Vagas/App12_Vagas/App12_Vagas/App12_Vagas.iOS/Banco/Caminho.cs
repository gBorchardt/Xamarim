using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using App12_Vagas.Banco;
using App12_Vagas.iOS.Banco;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Caminho))]
namespace App12_Vagas.iOS.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBancoDados)
        {
            
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var caminhoBiblioteca = Path.Combine(folder, "..", "Library");

            var caminhoBD = Path.Combine(caminhoBiblioteca, NomeArquivoBancoDados);

            return caminhoBD;
        }
    }
}