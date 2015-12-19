using AplicacaoWeb.IMCService;
using AplicacaoWeb.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;
using RestSharp;

namespace AplicacaoWeb.Data
{
    public static class IMCRepository
    {
        public static IMC ObterIMCViaWCF(double peso, double altura)
        {
            using (var client = new IMCServiceClient())
            {
                var retorno = client.CalcularIMC(peso, altura);

                var imc = new IMC()
                {
                    Peso = retorno.Peso,
                    Altura = retorno.Altura,
                    ValorIMC = retorno.ValorIMC,
                    DescSituacao = retorno.DescSituacao
                };

                return imc;
            }
        }

        public static IMC ObterIMCViaWebApiClient(double peso, double altura)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(
                    string.Format("{0}calculoimc?peso={1}&altura={2}", 
                    ConfigurationManager.AppSettings["UrlBase"],
                    peso.ToString().Replace(",", "."),
                    altura.ToString().Replace(",", "."))).Result;

                response.EnsureSuccessStatusCode();

                return response.Content.ReadAsAsync<IMC>().Result;
            }
        }

        public static IMC ObterIMCViaRestSharp(double peso, double altura)
        {
            RestClient client = new RestClient(
                ConfigurationManager.AppSettings["UrlBase"]);

            RestRequest requisicao = new RestRequest(
                string.Format("calculoimc?peso={0}&altura={1}",
                    peso.ToString().Replace(",", "."),
                    altura.ToString().Replace(",", ".")), Method.GET);

            IRestResponse<IMC> resposta = 
                client.Execute<IMC>(requisicao);

            return resposta.Data;
        }
    }
}