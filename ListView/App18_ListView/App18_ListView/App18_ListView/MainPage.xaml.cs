using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App18_ListView
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            ListaFuncionarios.ItemsSource = GetFuncionarios();
        }

        private List<Grupo> GetFuncionarios()
        {
            return new List<Grupo>
            {
                new Grupo("Diretor", "Diretor da empresa")
                {
                    new Pessoa(){ Nome = "Maigui", EhObrigatorio = true, RankEficiencia = 10},
                },

                new Grupo("Analista", "Equipe de analise")
                {
                    new Pessoa(){ Nome = "Marcos", EhObrigatorio = true, RankEficiencia = 9},
                    new Pessoa(){ Nome = "Jander", EhObrigatorio = false},
                },

                new Grupo("Qualidade","Equipe de qualidade")
                {
                    new Pessoa(){ Nome = "Rodrigo", EhObrigatorio = true, RankEficiencia = 7},
                    new Pessoa(){ Nome = "Pedro", EhObrigatorio = false},
                },

                new Grupo("Programador","Equipe de desenvolvimento")
                {
                    new Pessoa(){ Nome = "Gabriel", EhObrigatorio = true, RankEficiencia = 10},
                    new Pessoa(){ Nome = "Rafael", EhObrigatorio = false},
                    new Pessoa(){ Nome = "Leonardo", EhObrigatorio = false},
                },

                new Grupo("Suporte","Equipe de atendimento")
                {
                    new Pessoa(){ Nome = "Josiel", EhObrigatorio = true, RankEficiencia = 8},
                    new Pessoa(){ Nome = "Diogo", EhObrigatorio = false},
                    new Pessoa(){ Nome = "Gustavo", EhObrigatorio = false},
                    new Pessoa(){ Nome = "Paulo Fernando", EhObrigatorio = true, RankEficiencia = 7},
                    new Pessoa(){ Nome = "Lucas", EhObrigatorio = false},
                    new Pessoa(){ Nome = "Yuri", EhObrigatorio = false},
                    new Pessoa(){ Nome = "Ben Hur", EhObrigatorio = false},
                    new Pessoa(){ Nome = "Felipe", EhObrigatorio = false},
                    new Pessoa(){ Nome = "Matheus", EhObrigatorio = false},
                    new Pessoa(){ Nome = "Rafael", EhObrigatorio = false},
                },
            };
        }

        public class Grupo : List<Pessoa>
        {
            public string Titulo { get; set; }
            public string Descricao { get; set; }

            public Grupo(string titulo, string descricao)
            {
                this.Titulo = titulo;
                this.Descricao = descricao;
            }

        }

        public class Pessoa
        {
            public string Nome { get; set; }
            public int RankEficiencia { get; set; }
            public bool EhObrigatorio { get; set; }
        }
    }
}
