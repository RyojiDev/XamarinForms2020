using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1_ConsultarCep.Services.Model;
using App1_ConsultarCep.Services;

namespace App1_ConsultarCep
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BOTAO.Clicked += BuscarCep;
        }

        private void BuscarCep(object sender, EventArgs args)
        {
            
            //TODO - Validações.
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep)) {
                try { 
            Endereco end = ViaCepService.BuscarEnderecoViaCep(cep);

                    if(end != null) { 

            RESULTADO.Text = $"Endereço: {end.Localidade},{end.Uf}, {end.Logradouro}, {end.Bairro} ";
                    }
                    else
                    {
                        DisplayAlert("ERRO", "o endereço não foi encontrado para o CEP Informado: " + end.Cep , "OK");
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO CRIticon", e.Message,"OK");
                }
            }
            
        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;

            if(cep.Length != 8)
            {
                //Erro
                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");
                valido = false;
            }
            int NovoCEP = 0;
            if(!int.TryParse(cep, out NovoCEP)){
                //ERRO
                DisplayAlert("Erro", "CEP inválido, o CEP deve composto apenas por numeros", "OK");
                valido = false;
            }
            return valido;
        }
    }
}
