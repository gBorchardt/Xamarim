using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using Prism.Ioc;
using Prism;
using App30_PrismAndRealm.Views;
using App30_PrismAndRealm.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App30_PrismAndRealm
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override async void OnInitialized()
        {
            //Qual a primeira página

            InitializeComponent();

            DataBase.Massa.CriarMassaDados();

            // Padrão
            //App.Current.MainPage = new NavigationPage(new LoginPage());

            // No Prims usar:
            //NavigationService.NavigateAsync("NavigationPage/ListaProfissionaisPage");
            var result = await NavigationService.NavigateAsync("NavigationPage/ListaProfissionaisPage");

            if (result.Success)
            {
                
            }
            else
            {
                
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Registrar todas as views

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ListaProfissionaisPage, ListaProfissionaisPageViewModel>();
            containerRegistry.RegisterForNavigation<DetalheProfissionalPage, DetalheProfissionalPageViewModel>();
        }
    }
}
