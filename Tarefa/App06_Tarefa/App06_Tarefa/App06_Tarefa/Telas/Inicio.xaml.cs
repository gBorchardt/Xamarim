using App06_Tarefa.Modelos;
using App06_Tarefa.Servicos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App06_Tarefa.Telas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Inicio : ContentPage
	{
		public Inicio()
		{
			InitializeComponent();

            var culture = new CultureInfo("pt-BR");
            lblData.Text = string.Format(DateTime.Now.ToString("dddd, dd {0} MMMM {0} yyyy", culture), "de");

            ListarTarefas();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cadastro());
        }

        private void ListarTarefas()
        {
            SLTarefas.Children.Clear(); //Limpa os elementos do StackLayout Carregado padrão de teste

            var tarefas = new GerenciadorTarefa().Listagem();

            int i = 0;
            foreach (var tarefa in tarefas)
            {
                LinhaStackLayout(tarefa, i);
                i++;
            }
        }

        private void LinhaStackLayout(Tarefa tarefa, int index)
        {
            var imgcheckNome = string.Empty;
            object stackCentral = null;
            if (tarefa.DataFinalizacao == null)
            {
                imgcheckNome = "CheckOff.png";
                stackCentral = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand, Text = tarefa.Nome };
            }
            else
            {
                imgcheckNome = "CheckOn.png";
                stackCentral = new StackLayout() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand, Spacing = 0 };

                ((StackLayout)stackCentral).Children.Add(new Label() { Text = tarefa.Nome, TextColor = Color.Gray });
                ((StackLayout)stackCentral).Children.Add(new Label() { Text = "Finalizado em:" + tarefa.DataFinalizacao?.ToString("dd/MM/yyyy - hh:mm:ss"), TextColor = Color.Gray, FontSize = 10 });
            }
            

            var imgCheck = new Image() { VerticalOptions = LayoutOptions.Center };
            imgCheck.Source = ImageSource.FromFile(imgcheckNome);
            if (Device.RuntimePlatform == Device.UWP)
            {
                imgCheck.Source = ImageSource.FromFile($"Resources/{imgcheckNome}");
            }

            var checkTap = new TapGestureRecognizer();
            checkTap.Tapped += delegate
            {
                new GerenciadorTarefa().Finalizar(index, tarefa);
                ListarTarefas();
            };
            imgCheck.GestureRecognizers.Add(checkTap);

            var imgPrioridade = new Image() { VerticalOptions = LayoutOptions.Center };
            imgPrioridade.Source = ImageSource.FromFile("Image" + tarefa.Prioridade + ".png");
            if (Device.RuntimePlatform == Device.UWP)
            {
                imgPrioridade.Source = ImageSource.FromFile("Resources/Image" + tarefa.Prioridade + ".png");
            }

            var imgDelete = new Image() { VerticalOptions = LayoutOptions.Center };
            imgDelete.Source = ImageSource.FromFile("Delete.png");
            if (Device.RuntimePlatform == Device.UWP)
            {
                imgDelete.Source = ImageSource.FromFile("Resources/Delete.png");
                
            }

            var deleteTap = new TapGestureRecognizer();
            deleteTap.Tapped += delegate
            {
                new GerenciadorTarefa().Deletar(index);
                ListarTarefas();
            };
            imgDelete.GestureRecognizers.Add(deleteTap);

            var linha = new StackLayout() { Orientation = StackOrientation.Horizontal, Spacing = 15 };
            linha.Children.Add(imgCheck);
            linha.Children.Add((View)stackCentral);
            linha.Children.Add(imgPrioridade);
            linha.Children.Add(imgDelete);

            SLTarefas.Children.Add(linha);
        }
    }
}