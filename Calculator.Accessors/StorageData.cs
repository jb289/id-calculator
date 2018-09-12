using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Calculator.Accessors
{
    [DataContract]
    public class StorageData
    {

        [DataMember]
        public Guid InstanceId { get; set; }

        [DataMember]
        public double Value { get; set; }

    }
}
