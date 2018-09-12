using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using Calculator.Common.Contracts;

namespace Calculator.Accessors
{
    [ServiceContract]
    public interface IStorageAccessor : IServiceBase
    {
        [OperationContract]
        StorageData LoadStorageData(StorageData storageData);

        [OperationContract]
        bool ClearStorageData(StorageData storageData);

        [OperationContract]
        bool SetStorageData(StorageData storageData);

    }

}
