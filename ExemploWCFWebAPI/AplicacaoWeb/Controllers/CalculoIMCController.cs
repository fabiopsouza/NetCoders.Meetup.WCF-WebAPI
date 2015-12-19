using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AplicacaoWeb.IMCService;
using AplicacaoWeb.Models;

namespace AplicacaoWeb.Controllers
{
    public class CalculoIMCController : ApiController
    {
        [HttpGet]
        public object GetIMC(double peso, double altura)
        {
            var valorIMC = peso / (altura * altura);
            string descSituacao;

            if (valorIMC > 25)
                descSituacao = "Acima do Peso";
            else if (valorIMC < 18)
                descSituacao = "Abaixo do Peso";
            else
                descSituacao = "Peso normal";

            return new
            {
                Peso = peso,
                Altura = altura,
                ValorIMC = valorIMC,
                DescSituacao = descSituacao
            };
        }
    }
}
