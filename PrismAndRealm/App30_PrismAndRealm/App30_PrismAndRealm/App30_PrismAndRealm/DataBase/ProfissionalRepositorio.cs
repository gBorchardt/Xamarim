using App30_PrismAndRealm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App30_PrismAndRealm.DataBase
{
    public class ProfissionalRepositorio
    {
        public static List<Profissional> ObterProfissionais()
        {
            return new List<Profissional>(Realms.Realm.GetInstance().All<Profissional>());
        }
    }
}
