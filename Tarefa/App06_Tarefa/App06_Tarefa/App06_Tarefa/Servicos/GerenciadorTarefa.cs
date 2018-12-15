using App06_Tarefa.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App06_Tarefa.Servicos
{
    public class GerenciadorTarefa
    {
        private readonly string _key = "TAREFAS";

        public GerenciadorTarefa()
        {
            _lista = Listagem();
        }

        private List<Tarefa> _lista { get; set; }
        public List<Tarefa> Listagem()
        {
            return ListagemNoProprieties();
        }

        public void Salvar(Tarefa tarefa)
        {
            _lista.Add(tarefa);
            SalvarNoProperties();
        }

        public void Deletar(int index)
        {
            _lista.RemoveAt(index);
            SalvarNoProperties();
        }

        public void Finalizar(int index, Tarefa tarefa)
        {
            //_lista.Remove(tarefa);
            _lista.RemoveAt(index);


            tarefa.DataFinalizacao = DateTime.Now;
            _lista.Add(tarefa);
            SalvarNoProperties();
        }

        private void SalvarNoProperties()
        {
            if (App.Current.Properties.ContainsKey(_key))
            {
                App.Current.Properties.Remove(_key);
            }

            var jsonVal = JsonConvert.SerializeObject(_lista);

            App.Current.Properties.Add(_key, jsonVal);
        }

        private List<Tarefa> ListagemNoProprieties()
        {
            if (App.Current.Properties.ContainsKey(_key))
            {
                var jsonVal = (String)App.Current.Properties[_key];
                return JsonConvert.DeserializeObject<List<Tarefa>>(jsonVal);
            }

            return new List<Tarefa>();
        }
    }
}
