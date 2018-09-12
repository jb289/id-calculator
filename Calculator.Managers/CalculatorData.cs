using System;
using System.Runtime.Serialization;

namespace Calculator.Managers
{
    [DataContract]
    public class CalculatorData
    {
        [DataMember]
        public double Value { get; set; }

        [DataMember]
        public Guid InstanceId { get; set; }
    }
}
