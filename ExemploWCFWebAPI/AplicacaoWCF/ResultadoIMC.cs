using System.Runtime.Serialization;

namespace AplicacaoWCF
{
    [DataContract]
    public class ResultadoIMC
    {
        [DataMember]
        public double Peso { get; set; }

        [DataMember]
        public double Altura { get; set; }

        [DataMember]
        public double ValorIMC { get; set; }

        [DataMember]
        public string DescSituacao { get; set; }
    }
}