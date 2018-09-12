using System.ServiceModel;
using Calculator.Accessors;
using Calculator.Common.Contracts;

namespace Calculator.Managers
{
    [ServiceContract]
    public interface ITotalStorage
    {
        [OperationContract]
        void ClearTotal(CalculatorData calculatorData);

        [OperationContract]
        CalculatorData LoadTotal(CalculatorData calculatorData);

    }
}
