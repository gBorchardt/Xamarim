using App26_Annotation.Validacao;
using System.ComponentModel.DataAnnotations;

namespace App26_Annotation.Models
{
    public class Pessoa
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome é Obrigatório.")]
        [StringLength(60,MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessageResourceName = "Msg_Erro", ErrorMessageResourceType = typeof(Lang.Mensagem))]
        [EmailAddress(ErrorMessage = null, ErrorMessageResourceName = "Msg_Invalido", ErrorMessageResourceType = typeof(Lang.Mensagem))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "Msg_Erro", ErrorMessageResourceType = typeof(Lang.Mensagem))]
        [CpfAttibute(ErrorMessageResourceName = "Msg_Invalido", ErrorMessageResourceType = typeof(Lang.Mensagem))]
        public string Cpf { get; set; }
    }
}
