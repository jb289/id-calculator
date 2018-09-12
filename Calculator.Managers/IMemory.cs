using System.ServiceModel;
using Calculator.Accessors;
using Calculator.Common.Contracts;

namespace Calculator.Managers
{
    [ServiceContract]
    public interface IMemory
    {
        [OperationContract]
        void StoreToMemory(CalculatorData calculatorData);

        [OperationContract]
        CalculatorData RetrieveFromMemory(CalculatorData calculatorData);

        [OperationContract]
        void ClearMemory(CalculatorData calculatorData);


    }
}
