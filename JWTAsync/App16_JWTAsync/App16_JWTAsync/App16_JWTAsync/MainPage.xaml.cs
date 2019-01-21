using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App16_JWTAsync
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void GetTokenAction(object sender, EventArgs e)
        {
            var resultado = await Service.JWTService.GetToken(nome.Text, password.Text);
            lblToken.Text = resultado;

        }

        private async void VerificarAction(object sender, EventArgs e)
        {
            var resultado = await Service.JWTService.Verificar();
            lblResultado.Text = resultado;
        }

        /*

        Nota:
        Caso você queira acionar um método async usando MVVM ou dentro de um método normal(sem async na assinatura do método). 
        Use o trecho: Namespace: System.Threading.Task;

        Task.Run(async()=>{ await SeuMétodoAsync(); }); 

        Obs.: Pode ser usado em métodos chamados pelo Command ou Método Construtor e outros métodos que não se podem mudar a assinatura acrescentando Async.

        */
    }
}
