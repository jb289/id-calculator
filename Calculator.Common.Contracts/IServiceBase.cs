using System.ServiceModel;

namespace Calculator.Common.Contracts
{
    [ServiceContract]
    public interface IServiceBase
    {
        [OperationContract]
        string TestMe(string input);
    }
}
