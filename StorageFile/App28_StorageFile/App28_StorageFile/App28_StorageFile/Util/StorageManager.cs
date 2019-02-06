using PCLStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App28_StorageFile.Util
{
    //https://github.com/dsplaisted/PCLStorage
    public class StorageManager
    {
        public async static void SalvarConteudo(string fileName, string conteudo)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("arquivos",CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(conteudo);
        }

        public async static Task<string> LerConteudo(string fileName)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("arquivos",CreationCollisionOption.OpenIfExists);
            IFile file = await folder.GetFileAsync(fileName);
            return await file.ReadAllTextAsync();
        }
    }
}
