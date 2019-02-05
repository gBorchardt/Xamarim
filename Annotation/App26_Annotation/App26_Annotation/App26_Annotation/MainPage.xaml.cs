using App26_Annotation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App26_Annotation
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


            
            btnSalvar.Clicked += delegate
            {
                // Maneira clássica sem DataAnnotation
                // if (String.IsNullOrEmpty(txtNome.Text))
                // {
                //      lblMsg.Text = "O campo nome é obrigatório.";
                // }

                var pessoa = new Pessoa()
                {
                    Nome = txtNome.Text,
                    Email = txtEmail.Text,
                    Cpf = txtCpf.Text
                };

                var listaResults = new List<ValidationResult>();

                var contexto = new ValidationContext(pessoa);

                var isValid = Validator.TryValidateObject(pessoa, contexto, listaResults, true);

                if (listaResults.Count > 0)
                {
                    lblMsg.Text = string.Empty;
                    lblMsg.TextColor = Color.Red;

                    foreach (var result in listaResults)
                    {
                        lblMsg.Text += string.Format(result.ErrorMessage, result.MemberNames) + "\n";
                    }

                }
                else
                {
                    lblMsg.Text = "OK!";
                    lblMsg.TextColor = Color.Green;
                }
            };
        }
    }
}
