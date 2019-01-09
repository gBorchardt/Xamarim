using System;
using System.Collections.Generic;
using System.Text;
using App12_Vagas.Modelos;
using SQLite;
using Xamarin.Forms;

namespace App12_Vagas.Banco
{
    public class Database
    {
        private SQLiteConnection _conexao;

        public Database()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");

            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<Vaga>();

        }

        public List<Vaga> Listar(string palavra = "") 
        {
            var lista = _conexao.Table<Vaga>();

            if (!string.IsNullOrEmpty(palavra))
                lista = lista.Where(x => x.Cargo.ToUpper().Contains(palavra.ToUpper()));

            return lista.ToList();
        }

        public Vaga ObterPorId(int id)
        {
            return _conexao.Table<Vaga>().Where(x => x.Id == id).FirstOrDefault();
        }

        public void Cadastrar(Vaga vaga)
        {
            _conexao.Insert(vaga);
        }

        public void Atualizar(Vaga vaga)
        {
            _conexao.Update(vaga);
        }

        public void Excluir(Vaga vaga)
        {
            _conexao.Delete(vaga);
        }
    }
}
