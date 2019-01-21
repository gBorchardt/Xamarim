using App14_Chat.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App14_Chat.ViewModel
{
    public class CadastrarChatViewModel : INotifyPropertyChanged
    {
        private bool _carregando;
        public bool Carregando
        {
            get { return _carregando; }
            set { _carregando = value; OnPropertyChanged("Carregando"); }
        }

        private bool _msgErro;
        public bool MsgErro
        {
            get { return _msgErro; }
            set { _msgErro = value; OnPropertyChanged("MsgErro"); }
        }


        public string Nome { get; set; }

        public string _Mensagem { get; set; }
        public string Mensagem {
            get { return _Mensagem; }
            set { _Mensagem = value; OnPropertyChanged("Mensagem"); }
        }

        public Command CadastrarCommand { get; set; }

        public CadastrarChatViewModel()
        {
            CadastrarCommand = new Command(CadastrarAction);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        private void CadastrarAction()
        {
            bool resultado = Task.Run(() => Cadastrar()).GetAwaiter().GetResult();

            if (resultado)
            {
                var paginaAtual = (NavigationPage)App.Current.MainPage;
                paginaAtual.PopAsync();
            }
        }

        private async Task<bool> Cadastrar()
        {
            Carregando = true;
            _msgErro = false;

            try
            {
                var chat = new Chat()
                {
                    nome = Nome
                };

                bool ok = await Service.ServiceWS.PostChat(chat);

                if (ok)
                {
                    var paginaAtual = (NavigationPage)App.Current.MainPage;

                    var chats = (View.Chat)paginaAtual.RootPage;
                    var viewModel = (ChatViewModel)chats.BindingContext;

                    if (viewModel.AtualizarCommand.CanExecute(null))
                        viewModel.AtualizarCommand.Execute(null);

                    return true;
                }
                else
                {
                    throw new Exception("Ocorreu um erro no cadastro");
                }
            }
            catch (Exception ex)
            {
                Mensagem = ex.Message;
                Carregando = false;
                _msgErro = true;
                return false;
            }
        }
    }
}
