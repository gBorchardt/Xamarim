using App14_Chat.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App14_Chat.ViewModel
{
    public class ChatViewModel : INotifyPropertyChanged
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

        private List<Chat> _Chats;
        public List<Chat> Chats
        {
            get { return _Chats; }
            set { _Chats = value; OnPropertyChanged("Chats"); }
        }

        private Chat _SelectedItemChat;
        public Chat SelectedItemChat
        {
            get { return _SelectedItemChat; }
            set { _SelectedItemChat = value; OnPropertyChanged("SelectedItemChat"); GoPaginaMensagem(value); }
        }

        public Command AdicionarCommand { get; set; }
        public Command OrdenarCommand { get; set; }
        public Command AtualizarCommand { get; set; }

        public ChatViewModel()
        {
            Task.Run(()=> CarregarChats());

            AdicionarCommand = new Command(AdicionarAction);
            OrdenarCommand = new Command(OrdenarAction);
            AtualizarCommand = new Command(AtualizarAction);
        }

        private async Task CarregarChats()
        {
            try
            {
                Carregando = true;
                _msgErro = false;
                Chats = await Service.ServiceWS.GetChats();
                Carregando = false;
            }
            catch (Exception ex)
            {
                Carregando = false;
                _msgErro = true;
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        private void AdicionarAction()
        {
            ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.CadastrarChat());
        }

        private void OrdenarAction()
        {
            Chats = Chats.OrderBy(x => x.nome).ToList();
        }

        private void AtualizarAction()
        {
            Task.Run(() => CarregarChats());
        }

        private void GoPaginaMensagem(Chat chat)
        {
            if(chat != null)
            {
                SelectedItemChat = null;
                ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.Mensagem(chat));
            }
                
        }
    }
}
