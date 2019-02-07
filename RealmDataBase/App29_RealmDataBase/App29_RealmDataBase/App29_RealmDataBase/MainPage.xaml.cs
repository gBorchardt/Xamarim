using App29_RealmDataBase.Model;
using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App29_RealmDataBase
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnSalvar.Clicked += delegate
            {
                //Model
                var produto = new Produto()
                {
                    Item = txtItem.Text,
                    Quantidade = int.Parse(txtQuantidade.Text)
                };

                //Validar
                var listRes = new List<ValidationResult>();
                var contexto = new ValidationContext(produto);
                var validator = Validator.TryValidateObject(produto, contexto, listRes, true);

                if (listRes.Count > 0)
                {
                    var mensagem = string.Empty;

                    foreach (var erro in listRes)
                        mensagem += erro.ErrorMessage + "/n";

                    DisplayAlert("Erros", mensagem, "OK");

                    return;
                }

                //Salvar
                var realm = Realm.GetInstance();
                var update = false;

                if(string.IsNullOrEmpty(txtId.Text))
                {
                    if (realm.All<Produto>().Count() > 0)
                    {
                        var ultimoProduto = realm.All<Produto>().OrderByDescending(x => x.Id).First();

                        if (ultimoProduto != null)
                            produto.Id = ultimoProduto.Id + 1;
                    }
                    else
                        produto.Id = 1;

                }
                else
                {
                    update = true;
                    produto.Id = int.Parse(txtId.Text);
                }

                realm.Write(() => {
                    realm.Add(produto, update);
                });

                lstItens.ItemsSource = Realm.GetInstance().All<Produto>();
                DisplayAlert("Salvo com Sucesso", "Quantidade de Itens: " + realm.All<Produto>().Count(), "OK");
                LimparTela();
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lstItens.ItemsSource = Realm.GetInstance().All<Produto>();
        }

        private void ExcluirItem_Clicked(object sender, EventArgs e)
        {
            var produto = ((Produto)((MenuItem)sender).CommandParameter);

            //Remove produto
            var realm = Realm.GetInstance();

            realm.Write(() =>
            {
                realm.Remove(produto);
            });


            //Atualiza lista
            lstItens.ItemsSource = Realm.GetInstance().All<Produto>();
        }

        private void EditarItem_Clicked(object sender, EventArgs e)
        {
            var produto = ((Produto)((MenuItem)sender).CommandParameter);

            txtId.Text = produto.Id.ToString();
            txtItem.Text = produto.Item;
            txtQuantidade.Text = produto.Quantidade.ToString();
        }

        private void LimparTela()
        {
            txtId.Text = string.Empty;
            txtItem.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
        }
    }
}
