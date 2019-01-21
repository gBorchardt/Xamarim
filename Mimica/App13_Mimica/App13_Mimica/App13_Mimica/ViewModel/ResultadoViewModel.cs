using App13_Mimica.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App13_Mimica.ViewModel
{
    public class ResultadoViewModel : INotifyPropertyChanged
    {
        public Jogo Jogo { get; set; }

        public Command JogarNovamenteCommand { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string nameProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProperty));
        }

        public ResultadoViewModel()
        {
            Jogo = Armazenamento.Armazenamento.Jogo;

            JogarNovamenteCommand = new Command(JogarNovamenteAction);
        }

        private void JogarNovamenteAction()
        {
            App.Current.MainPage = new View.Inicio();
        }
    }
}
