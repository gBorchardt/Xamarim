using App13_Mimica.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App13_Mimica.ViewModel
{
    public class JogoViewModel : INotifyPropertyChanged
    {
        private readonly Grupo _grupo;

        public string NomeGrupo { get; set; }
        public string NumeroGrupo { get; set; }

        private string _Palavra;
        public string Palavra { get { return _Palavra; } set { _Palavra = value; OnPropertyChanged("Palavra"); } }

        private string _TextoContagem;
        public string TextoContagem { get { return _TextoContagem; } set { _TextoContagem = value; OnPropertyChanged("TextoContagem"); } }

        private byte _PalavraPontuacao;
        public byte PalavraPontuacao { get { return _PalavraPontuacao; } set { _PalavraPontuacao = value; OnPropertyChanged("PalavraPontuacao"); } }

        private bool _IsVisibleContainerContagem;
        public bool IsVisibleContainerContagem { get { return _IsVisibleContainerContagem; } set { _IsVisibleContainerContagem = value; OnPropertyChanged("IsVisibleContainerContagem"); } }

        private bool _IsVisibleBtnIniciar;
        public bool IsVisibleBtnIniciar { get { return _IsVisibleBtnIniciar; } set { _IsVisibleBtnIniciar = value; OnPropertyChanged("IsVisibleBtnIniciar"); } }

        private bool _IsVisibleBtnMostrar;
        public bool IsVisibleBtnMostrar { get { return _IsVisibleBtnMostrar; } set { _IsVisibleBtnMostrar = value; OnPropertyChanged("IsVisibleBtnMostrar"); } }

        public Command MostrarPalavraCommand { get; set; }
        public Command IniciarCommand { get; set; }
        public Command AcertouCommand { get; set; }
        public Command ErrouCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string nameProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProperty));
        }

        public JogoViewModel(Grupo grupo)
        {
            _grupo = grupo;
            NomeGrupo = grupo.Nome;

            if (grupo == Armazenamento.Armazenamento.Jogo.Grupo1)
                NumeroGrupo = "Grupo 1 - ";
            else
                NumeroGrupo = "Grupo 2 - ";


            Palavra = "**********";

            IsVisibleContainerContagem = false;
            IsVisibleBtnIniciar = false;
            IsVisibleBtnMostrar = true;

            MostrarPalavraCommand = new Command(MostrarPalavraAction);
            IniciarCommand = new Command(IniciarAction);
            AcertouCommand = new Command(AcertouAction);
            ErrouCommand = new Command(ErrouAction);
            
        }

        private void MostrarPalavraAction()
        {
            var nivelNumerico = Armazenamento.Armazenamento.Jogo.NivelNumerico;

            var random = new Random();
            var indice = 0;
            switch (nivelNumerico)
            {
                case 0: //Aleatório
                    int nivel = random.Next(0, 2);
                    indice = random.Next(0, Armazenamento.Armazenamento.Palavras[nivel].Length);
                    Palavra = Armazenamento.Armazenamento.Palavras[nivel][indice];
                    PalavraPontuacao = (byte) ((nivel == 0) ? 1 : (nivel == 1) ? 3 : 5);
                    break;
                case 1: //Fácil
                    indice = random.Next(0, Armazenamento.Armazenamento.Palavras[nivelNumerico - 1].Length);
                    Palavra = Armazenamento.Armazenamento.Palavras[nivelNumerico - 1][indice];
                    PalavraPontuacao = 1;
                    break;
                case 2: //Médio
                    indice = random.Next(0, Armazenamento.Armazenamento.Palavras[nivelNumerico - 1].Length);
                    Palavra = Armazenamento.Armazenamento.Palavras[nivelNumerico - 1][indice];
                    PalavraPontuacao = 3;
                    break;
                case 3: //Difícil
                    indice = random.Next(0, Armazenamento.Armazenamento.Palavras[nivelNumerico - 1].Length);
                    Palavra = Armazenamento.Armazenamento.Palavras[nivelNumerico - 1][indice];
                    PalavraPontuacao = 5;
                    break;
            }

            IsVisibleBtnMostrar = false;
            IsVisibleBtnIniciar = true;
        }

        private void IniciarAction()
        {
            IsVisibleBtnIniciar = false;
            IsVisibleContainerContagem = true;

            var i = Armazenamento.Armazenamento.Jogo.Tempo;
            TextoContagem = i.ToString();
            i--;
            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                TextoContagem = i.ToString();
                i--;

                if (i <= 0)
                    TextoContagem = "FIM";

                return true;
            });
        }

        private void AcertouAction()
        {

            _grupo.Pontuacao += PalavraPontuacao;

            GoProximoGrupo();
        }

        private void ErrouAction()
        {
            GoProximoGrupo();
        }

        private void GoProximoGrupo()
        {
            //TODO - Verificar se a rodada terminou

            Grupo proximoGrupo;
            if (Armazenamento.Armazenamento.Jogo.Grupo1 == _grupo)
            {
                proximoGrupo = Armazenamento.Armazenamento.Jogo.Grupo2;
            }
            else
            {
                proximoGrupo = Armazenamento.Armazenamento.Jogo.Grupo1;
                Armazenamento.Armazenamento.RodadaAtual++;
            }

            if (Armazenamento.Armazenamento.RodadaAtual > Armazenamento.Armazenamento.Jogo.Rodadas)
            {
                App.Current.MainPage = new View.Resultado();
            }
            else
            {
                App.Current.MainPage = new View.Jogo(proximoGrupo);
            }
        }
    }
}
