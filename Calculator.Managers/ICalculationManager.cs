using System.ServiceModel;
using Calculator.Accessors;
using Calculator.Common.Contracts;

namespace Calculator.Managers
{
    [ServiceContract]
    public interface ICalculationManager : ITotalStorage, IMemory, IServiceBase
    {
        [OperationContract]
        CalculatorData GetCalculationResult(CalculationRequest request);

    }
}
