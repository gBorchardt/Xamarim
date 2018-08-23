using App01_ConsultarCEP.Servico;
using System;
using Xamarin.Forms;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BOTAO.Clicked += BuscarCep;
		}

        private void BuscarCep(object sender, EventArgs e)
        {
            var cep = CEP.Text.Trim();

            if (IsValidCep(cep))
            {
                try
                {
                    var resultado = ViaCepServico.BuscarEndecoViaCep(cep);

                    if (resultado == null)
                        DisplayAlert("ERRO", $"Endereço não encontrado para o CEP informado: {cep}", "OK");

                    RESULTADO.Text = $"Endereço: {resultado.logradouro}, Bairro:{resultado.bairro} - {resultado.localidade} / {resultado.uf} - CEP: {resultado.cep}";
                }
                catch (Exception ex)
                {
                    DisplayAlert("ERRO CRÍTICO", ex.Message, "OK");
                }
            }
        }

        private bool IsValidCep(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve conter 8 caracteres.", "OK");
                valido = false;
            }

            if (!int.TryParse(cep, out int NovoCep))
            {
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve conter apenas números.", "OK");
                valido = false;
            }

            return valido;
        }
    }
}
