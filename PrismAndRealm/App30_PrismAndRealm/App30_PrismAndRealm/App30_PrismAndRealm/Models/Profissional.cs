using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace App30_PrismAndRealm.Models
{
    public class Profissional : RealmObject
    {
        [PrimaryKey]
        public string Nome { get; set; }
        public string Img { get; set; }
        public string Descricao { get; set; }
        public string Especialidade { get; set; }

        public IList<Comentario> Comentarios { get;}
    }
}
