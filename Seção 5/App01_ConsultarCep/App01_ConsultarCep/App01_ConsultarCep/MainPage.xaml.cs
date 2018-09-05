using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCep.Servico.Modelo;
using App01_ConsultarCep.Servico;

namespace App01_ConsultarCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = CEP.Text.Trim();

            if(isValidCEP(cep)){
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço \nEstado: {0} \nUF: {1}\nBairro: {2}\nLogradouro: {3} \nComplemento: {4}", end.localidade, end.uf, end.bairro, end.logradouro, end.complemento);
                    }
                    else
                    {
                        DisplayAlert("ERRO CRITÍCO", "O endereço não foi encontrado para o cep digitado: " + cep, "OK");
                    }
                }
                catch(Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }

            }else{
                //T
            }
        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;

            if (cep.Length != 8) { 
    
                DisplayAlert("ERRO", "CEP inválido! CEP deve conter 8 dígitos", "OK");
       
                valido = false;
            }
            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve ser composto apenas por núneros", "OK");
                valido = false;
            }
            return valido;
        }
    }
}
