using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AplicacaoWCF
{
    [ServiceContract]
    public interface IIMCService
    {
        [OperationContract]
        ResultadoIMC CalcularIMC(double peso, double altura);
    }
}
