using App14_Chat.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App14_Chat.Util
{
    public class MensagemDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MensagemPropriaTemplate { get; set; }
        public DataTemplate MensagemOutrosUsuariosTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var usuarioLogado = UsuarioUtil.GetUsuarioLogado();

            return ((Mensagem)item).id_usuario == usuarioLogado.id ? MensagemPropriaTemplate : MensagemOutrosUsuariosTemplate;
        }
    }
}
