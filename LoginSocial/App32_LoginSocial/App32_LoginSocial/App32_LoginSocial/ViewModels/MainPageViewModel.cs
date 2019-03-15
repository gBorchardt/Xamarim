using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;

// OAuth
// Xamarin Forms:
//  - Android, iOS e UWP - Custom Renderer (PageRenderer - Tela é do próprio provedor de login - Facebook, Google)

namespace App32_LoginSocial.ViewModels
{
	public class MainPageViewModel : BindableBase, INavigationAware
	{
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand LoginFacebookCommand
        {
            get;
            set;
        }

        public MainPageViewModel()
        {
            LoginFacebookCommand = new DelegateCommand(LoginFacebook);
        }

        private void LoginFacebook()
        {
            App.Current.MainPage = new Views.LoginFacebook();
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
