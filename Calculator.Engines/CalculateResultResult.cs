using System.Runtime.Serialization;

namespace Calculator.Engines
{
    [DataContract]
    public class CalculateResultResult
    {
        [DataMember]
        public double Result { get; set; }
    }
}
