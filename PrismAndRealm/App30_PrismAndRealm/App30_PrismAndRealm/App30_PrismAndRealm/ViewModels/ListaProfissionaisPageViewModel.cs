using App30_PrismAndRealm.DataBase;
using App30_PrismAndRealm.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App30_PrismAndRealm.ViewModels
{
	public class ListaProfissionaisPageViewModel : BindableBase
	{
        private INavigationService _navigationService;

        private List<Profissional> _listaProf;
        public List<Profissional> ListaProf
        {
            get { return _listaProf; }
            set { SetProperty(ref _listaProf, value); }
        }

        public DelegateCommand<Profissional> ProfissionalCommand { get; set; }

        public ListaProfissionaisPageViewModel(INavigationService navigationService)
        {
            ListaProf = ProfissionalRepositorio.ObterProfissionais();
            ProfissionalCommand = new DelegateCommand<Profissional>(ExecuteProfissionalCommand);
            _navigationService = navigationService;
        }

        private void ExecuteProfissionalCommand(Profissional profissional)
        {
            var navParameters = new NavigationParameters
            {
                { "profissional", profissional }
            };
            
            _navigationService.NavigateAsync("DetalheProfissionalPage", navParameters);
        }
    }
}
