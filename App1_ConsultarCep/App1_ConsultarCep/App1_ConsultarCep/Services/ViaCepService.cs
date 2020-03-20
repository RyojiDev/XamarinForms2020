using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App1_ConsultarCep.Services.Model;
using Newtonsoft.Json;


namespace App1_ConsultarCep.Services
{
    public class ViaCepService
    {
        private static string EnderecoURL = "http://viacep.com.br/ws{0}/json/";

        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            return end;
        }
    }
}
