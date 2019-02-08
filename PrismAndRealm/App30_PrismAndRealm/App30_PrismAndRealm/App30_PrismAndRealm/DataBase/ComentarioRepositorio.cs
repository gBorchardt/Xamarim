using App30_PrismAndRealm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App30_PrismAndRealm.DataBase
{
    public class ComentarioRepositorio
    {
        public static List<Comentario> ObterComentarios(Profissional profissional)
        {
            return new List<Comentario>(Realms.Realm.GetInstance().All<Comentario>().Where(x => x.profissional == profissional));
        }
    }
}
