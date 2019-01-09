using App12_Vagas.Banco;
using App12_Vagas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App12_Vagas.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastrarVaga : ContentPage
    {
        private Vaga _vaga;
        public CadastrarVaga(Vaga vaga = null)
        {
            InitializeComponent();

            if (vaga != null)
            {
                _vaga = vaga;
                ListaVaga();
            }
        }

        private void ListaVaga()
        {
            Cargo.Text = _vaga.Cargo;
            Empresa.Text = _vaga.Empresa;
            Quantidade.Text = _vaga.Quantidade.ToString();
            Cidade.Text = _vaga.Cidade;
            Salario.Text = _vaga.Salario.ToString();
            Descricao.Text = _vaga.Descricao;
            TipoContratacao.IsToggled = _vaga.TipoContratacao == "PJ" ? true : false;
            Telefone.Text = _vaga.Telefone;
            Email.Text = _vaga.Email;

        }

        private void SalvarAction(object sender, EventArgs e)
        {
            if (_vaga == null)
                _vaga = new Vaga();

            _vaga.Cargo = Cargo.Text;
            _vaga.Empresa = Empresa.Text;
            _vaga.Quantidade = short.Parse(Quantidade.Text);
            _vaga.Cidade = Cidade.Text;
            _vaga.Salario = double.Parse(Salario.Text);
            _vaga.Descricao = Descricao.Text;
            _vaga.TipoContratacao = TipoContratacao.IsToggled ? "PJ" : "CLT";
            _vaga.Telefone = Telefone.Text;
            _vaga.Email = Email.Text;

            if (_vaga.Id == 0)
            {
                new Database().Cadastrar(_vaga);
            }
            else
            {
                new Database().Atualizar(_vaga);
            }
            

            App.Current.MainPage = new NavigationPage(new ConsultarVagas());

        }
    }
}