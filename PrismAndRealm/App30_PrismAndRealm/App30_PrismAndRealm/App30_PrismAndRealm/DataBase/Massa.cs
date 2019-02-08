using App30_PrismAndRealm.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App30_PrismAndRealm.DataBase
{
    public class Massa
    {
        public static void CriarMassaDados()
        {
            var realm = Realm.GetInstance();

            realm.Write(() =>
            {
                realm.RemoveAll<Profissional>();
                realm.RemoveAll<Comentario>();


                for (int i = 1; i <= 20; i++)
                {
                    var profissional = new Profissional()
                    {
                        Nome = "Prof " + i,
                        Descricao = "Desc  " + i,
                        Especialidade = "Espec " + i,
                        Img = "http://neoleader.com.br/wp-content/uploads/2015/05/geral_adulto-300x300.png",
                    };

                    realm.Add<Profissional>(profissional);

                    for (int j = 1; j <= 3; j++)
                    {
                        var comentario = new Comentario()
                        {
                            profissional = profissional,
                            Autor = string.Format("Autor {0} {1}", i, j),
                            Data = DateTimeOffset.Now,
                            Descricao = string.Format("Descrição {0} {1}", i, j)
                        };

                        realm.Add<Comentario>(comentario);
                    }
                }
            });
        }
    }
}
