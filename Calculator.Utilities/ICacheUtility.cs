using System.ServiceModel;
using Calculator.Common.Contracts;

namespace Calculator.Utilities
{
    [ServiceContract]
    public interface ICacheUtility : IServiceBase
    {

        [OperationContract]
        void SaveToCache(CacheData cacheData);

        [OperationContract]
        void ClearCache(CacheData cacheData);

        [OperationContract]
        CacheData RetrieveFromCache(CacheData cacheData);

    }

}
