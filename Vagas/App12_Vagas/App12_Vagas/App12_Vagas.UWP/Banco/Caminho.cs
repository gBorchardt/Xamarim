using App12_Vagas.Banco;
using Xamarin.Forms;
using System.IO;
using App12_Vagas.UWP.Banco;
using Windows.Storage;

[assembly: Dependency(typeof(Caminho))]
namespace App12_Vagas.UWP.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBancoDados)
        {
            
            var folder = ApplicationData.Current.LocalFolder.Path;

            var caminhoBD = Path.Combine(folder, NomeArquivoBancoDados);

            return caminhoBD;
        }
    }
}