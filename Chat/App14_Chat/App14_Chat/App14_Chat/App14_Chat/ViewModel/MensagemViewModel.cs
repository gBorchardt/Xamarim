using App14_Chat.Model;
using App14_Chat.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App14_Chat.ViewModel
{
    public class MensagemViewModel : INotifyPropertyChanged
    {
        //private StackLayout _SL;

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

        private Chat _chat;
        
        private List<Mensagem> _Mensagens;
        public List<Mensagem> Mensagens
        {
            get { return _Mensagens; }
            set {
                _Mensagens = value;
                OnPropertyChanged("Mensagens");
                //if(value != null)
                //    ShowOnScreen();
            }
        }

        private string _Mensagem;
        public string Mensagem
        {
            get { return _Mensagem; }
            set {
                _Mensagem = value;
                OnPropertyChanged("Mensagem");
            }
        }

        public Command EnviarCommand { get; set; }
        public Command AtualizarCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }


        public MensagemViewModel(Chat chat)//, StackLayout SLMensagemContainer)
        {
            _chat = chat;
            //_SL = SLMensagemContainer;
            Task.Run(() => Atualizar());

            EnviarCommand = new Command(EnviarAction);
            AtualizarCommand = new Command(AtualizarAction);

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                Task.Run(() => AtualizarSemTelaCarregando());
                return true;
            });
        }

        private void AtualizarAction()
        {
            Task.Run(() => Atualizar());
        }

        private async Task Atualizar()
        {
            try
            {
                Carregando = true;
                _msgErro = false;
                Mensagens = await Service.ServiceWS.GetMensagens(_chat);
                Carregando = false;
            }
            catch (Exception ex)
            {
                Carregando = false;
                _msgErro = true;
            }
        }

        private async Task AtualizarSemTelaCarregando()
        {
            Mensagens = await Service.ServiceWS.GetMensagens(_chat);
        }

        private void EnviarAction()
        {
            var mensagem = new Mensagem()
            {
                id_chat = _chat.id,
                id_usuario = UsuarioUtil.GetUsuarioLogado().id,
                mensagem = Mensagem
            };

            Service.ServiceWS.PostMensagem(mensagem);
            Task.Run(() => Atualizar());
            Mensagem = string.Empty;
        }

        //private void ShowOnScreen()
        //{
            //var usuarioLogado = UsuarioUtil.GetUsuarioLogado();

            //_SL.Children.Clear();
            //foreach (var Mensagem in Mensagens)
            //{
            //    if (Mensagem.usuario.id == usuarioLogado.id)
            //        _SL.Children.Add(CriarMensagemPropria(Mensagem));
            //    else
            //        _SL.Children.Add(CriarMensagemOutrosUsuarios(Mensagem));
            //}
        //}

        //private Xamarin.Forms.View CriarMensagemOutrosUsuarios(Mensagem mensagem)
        //{
        //    var frame = new Frame()
        //    {
        //        OutlineColor = Color.FromHex("#5ED055"),
        //        CornerRadius = 0,
        //        HorizontalOptions = LayoutOptions.Start
        //    };

        //    var SL = new StackLayout();

        //    var labelNome = new Label()
        //    {
        //        Text = mensagem.usuario.nome,
        //        FontSize = 10,
        //        TextColor = Color.FromHex("#5ED055")
        //    };

        //    var labelMensagem = new Label()
        //    {
        //        Text = mensagem.mensagem,
        //        TextColor = Color.FromHex("#5ED055")
        //    };

        //    SL.Children.Add(labelNome);
        //    SL.Children.Add(labelMensagem);

        //    frame.Content = SL;

        //    return frame;
        //}

        //private Xamarin.Forms.View CriarMensagemPropria(Mensagem mensagem)
        //{
        //    var SL = new StackLayout()
        //    {
        //        Padding = 5,
        //        BackgroundColor = Color.FromHex("#5ED055"),
        //        HorizontalOptions = LayoutOptions.End
        //    };

        //    var label = new Label()
        //    {
        //        TextColor = Color.White,
        //        Text = mensagem.mensagem
        //    };

        //    SL.Children.Add(label);

        //    return SL;
        //}
    }
}
