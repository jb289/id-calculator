using System;
using System.Runtime.Serialization;

namespace Calculator.Utilities
{
    [DataContract]
    public class CacheData
    {
        [DataMember]
        public Guid InstanceId { get; set; }

        [DataMember]
        public double Value { get; set; }

    }
}
