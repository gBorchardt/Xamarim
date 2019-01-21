using App13_Mimica.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App13_Mimica.ViewModel
{
    public class InicioViewModel : INotifyPropertyChanged
    {
        public Jogo Jogo { get; set; }
        public Command IniciarCommand { get; set; }

        private string _MsgErro;
        public string MsgErro { get { return _MsgErro; } set { _MsgErro = value; OnPropertyChanged("MsgErro"); } }

        public InicioViewModel()
        {
            IniciarCommand = new Command(IniciarJogo);
            Jogo = new Jogo
            {
                Grupo1 = new Grupo(),
                Grupo2 = new Grupo()
            };

            Jogo.Tempo = 120;
            Jogo.Rodadas = 5;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string nameProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProperty));
        }

        private void IniciarJogo()
        {
            var error = string.Empty;
            if(Jogo.Tempo < 10)
                error += "Tempo mínimo para cada palavra é 10 segundos.";
            else if (Jogo.Rodadas <= 0)
                error += "\nDeve existir ao menos 1 rodada";

            if (error.Length > 0)
                MsgErro = error;
            else
            {
                Armazenamento.Armazenamento.Jogo = this.Jogo;
                Armazenamento.Armazenamento.RodadaAtual = 1;

                App.Current.MainPage = new View.Jogo(Jogo.Grupo1);
            }

        }
    }
}
