using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App13_Mimica.ViewModel
{
    public class CabecalhoViewModel 
    {
        public Command ReiniciarCommand { get; set; }

        public CabecalhoViewModel()
        {
            ReiniciarCommand = new Command(ReiniciarAction);
        }

        private void ReiniciarAction()
        {
            App.Current.MainPage = new View.Inicio();
        }
    }
}
