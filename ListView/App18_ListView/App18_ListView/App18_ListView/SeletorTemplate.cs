using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static App18_ListView.MainPage;

namespace App18_ListView
{
    public class SeletorTemplate : DataTemplateSelector
    {
        DataTemplate ItemPessoaObrigatoria;
        DataTemplate ItemPessoaNaoObrigatoria;

        public SeletorTemplate()
        {
            ItemPessoaObrigatoria = new DataTemplate(typeof(Templates.ItemPessoaObrigatoriaViewCell));
            ItemPessoaNaoObrigatoria = new DataTemplate(typeof(Templates.ItemPessoaNaoObrigatoriaViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var pessoa = item as Pessoa;

            if (pessoa.EhObrigatorio)
                return ItemPessoaObrigatoria;
            else
                return ItemPessoaNaoObrigatoria;
        }
    }
}
