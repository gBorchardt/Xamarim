using App14_Chat.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using App14_Chat.Service;
using Newtonsoft.Json;
using App14_Chat.Util;

namespace App14_Chat.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
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

        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; OnPropertyChanged("Nome"); }
        }

        private string _Senha;
        public string Senha
        {
            get { return _Senha; }
            set { _Senha = value; OnPropertyChanged("Senha"); }
        }

        private string _Mensagem;
        public string Mensagem
        {
            get { return _Mensagem; }
            set { _Mensagem = value; OnPropertyChanged("Mensagem"); }
        }

        public Command EntrarCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public LoginViewModel()
        {
            EntrarCommand = new Command(EntrarAction);
        }

        private async void EntrarAction()
        {
            try
            {
                Carregando = true;
                _msgErro = false;

                var usuario = new Usuario()
                {
                    nome = Nome,
                    password = Senha
                };

                var usuarioLogado = await ServiceWS.GetUsuario(usuario);
                if (usuarioLogado == null)
                {

                    Mensagem = "Usuário/Senha não conferem";
                    Carregando = false;
                }
                else
                {
                    UsuarioUtil.SetUsuarioLogado(usuarioLogado);
                    //App.Current.Properties["LOGIN"] = JsonConvert.SerializeObject(usuarioLogado);
                    App.Current.MainPage = new NavigationPage(new View.Chat()) { BarBackgroundColor = Color.FromHex("#5ED055"), BarTextColor = Color.White };
                }
            }
            catch (Exception ex)
            {
                MsgErro = true;
            }
            finally
            {
                Carregando = false;
            }
            

        }
    }
}
