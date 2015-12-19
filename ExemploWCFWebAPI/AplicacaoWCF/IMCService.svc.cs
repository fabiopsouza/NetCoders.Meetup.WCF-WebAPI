using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AplicacaoWCF
{
    public class IMCService : IIMCService
    {
        public ResultadoIMC CalcularIMC(double peso, double altura)
        {
            var imc = new ResultadoIMC
            {
                Peso = peso, 
                Altura = altura, 
                ValorIMC = peso/(altura*altura)
            };

            if (imc.ValorIMC > 25)
                imc.DescSituacao = "Acima do Peso";
            else if(imc.ValorIMC < 18)
                imc.DescSituacao = "Abaixo do Peso";
            else
                imc.DescSituacao = "Peso normal";

            return imc;
        }
    }
}
