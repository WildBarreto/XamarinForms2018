using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ConsultarCep.Servico.Modelo;
using ConsultarCep.Servico;

namespace ConsultarCep
{
    public partial class MainPage : ContentPage
    {
        private readonly string cep;

        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCep;
        }


        private void BuscarCep(object sender, EventArgs args)//para atender aos padrões de um evento hendler é preciso ter dois parametros, object sender e o EventArgs args
        {
            //Todo - Validação
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {

                        RESULTADO.Text = string.Format("Endereço: {0},{1},{2}" + end.localidade, end.uf, end.logradouro);

                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado");
                    }
                    
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO CRÌTICO", e.Message, "OK");
                   
                }
               
                
            }
           
            
        }

        private void DisplayAlert(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;
            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "cep inválido! o cep deve conter 8 caracteres.", "ok");     
                //Erro
                valido = false;
            }

            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("Erro", "O cep deve ser composto apenas por numeros.", "ok");
                //Erro
                valido = false;
            }
            return true;
        }
       
    }
}
