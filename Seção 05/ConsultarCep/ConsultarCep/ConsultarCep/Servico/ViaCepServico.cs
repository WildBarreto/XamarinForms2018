using System;
using System.Collections.Generic;
using System.Text;
using ConsultarCep.Servico.Modelo;
using System.Net;
using Newtonsoft.Json;

//Classe para fazer o dowload das informações do endereço
namespace ConsultarCep.Servico
{
    class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);// Para ter informções da endereço URL construido

            WebClient wc = new WebClient(); //webclient é da biblioteca system.net
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);/*conteudo da internet sera convertido
            em um objeto do tipo endeço*/

            if (end.cep == null)
            {
                return null;
            }

            return end;
        }
        
    }
}
