using System;
using System.Runtime.Serialization;

namespace Calculator.Engines
{
    [DataContract]
    public class CalculateResultRequest
    {
        [DataMember]
        public Guid InstanceId { get; set; }

        [DataMember]
        public double Operand1 { get; set; }
        [DataMember]
        public double Operand2 { get; set; }
        [DataMember]
        public string Operator { get; set; }
    }
}
