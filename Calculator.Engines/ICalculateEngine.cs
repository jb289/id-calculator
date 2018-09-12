using System.ServiceModel;
using Calculator.Common.Contracts;

namespace Calculator.Engines
{
    [ServiceContract]
    public interface ICalculateEngine : IServiceBase
    {
        [OperationContract]
        CalculateResultResult CalculateResult(CalculateResultRequest request);
    }
}
