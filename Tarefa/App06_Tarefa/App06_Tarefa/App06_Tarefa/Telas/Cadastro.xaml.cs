using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App06_Tarefa.Telas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cadastro : ContentPage
	{
        private byte _prioridade { get; set; }

		public Cadastro ()
		{
			InitializeComponent ();
		}

        private void PrioridadeSelectAction(object sender, EventArgs e)
        {
            var stacks = SLPrioridades.Children; //Recebe a lista de Stacks

            foreach (var stack in stacks)
            {
                //Conforme StackLayout XAML
                //stack.Children[0] = Image
                //stack.Children[1] = Label

                var lblPrioridade = ((StackLayout)stack).Children[1] as Label;
                lblPrioridade.TextColor = Color.Gray;
            }

            ((Label)((StackLayout)sender).Children[1]).TextColor = Color.Black;

            var imagem = ((Image)((StackLayout)sender).Children[0]).Source as FileImageSource;

            var prioriade = imagem.File.ToString().Replace("Resources/","").Replace("Image","").Replace(".png","");

            _prioridade = byte.Parse(prioriade);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var erroExiste = false;

            //Validar campos
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                DisplayAlert("ERRO", "Nome não preenchido", "OK");
                erroExiste = true;
            }

            if (_prioridade == 0)
            {
                DisplayAlert("ERRO", "Prioridade não selecionada", "OK");
                erroExiste = true;
            }

            if (!erroExiste)
            {
                var tarefa = new Modelos.Tarefa
                {
                    Nome = txtNome.Text.Trim(),
                    Prioridade = _prioridade
                };

                new Servicos.GerenciadorTarefa().Salvar(tarefa);

                App.Current.MainPage = new NavigationPage(new Inicio());
            }                
        }
    }
}