using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.ServiceModel;
using System.Text;
using Calculator.Accessors;
using Calculator.Common.Contracts;
using Calculator.Engines;
using Calculator.Utilities;

namespace Calculator.Managers
{
    public class CalculationManager : ManagerBase, ICalculationManager
    {
        private readonly ICalculateEngine _calculateEngine = null;
        private ICalculateEngine CalculateEngine => _calculateEngine ?? base.EngineFactory.Create<ICalculateEngine>();

        private readonly IStorageAccessor _storageAccessor = null;
        private IStorageAccessor StorageAccessor => _storageAccessor ?? base.AccessorFactory.Create<IStorageAccessor>();

        private readonly ICacheUtility _cacheUtility = null;
        private ICacheUtility CacheUtility => _cacheUtility ?? base.UtilityFactory.Create<ICacheUtility>();

        public CalculationManager(){}

        public CalculatorData GetCalculationResult(CalculationRequest request)
        {
            //TODO: Operators
            var inputRequest = new CalculateResultRequest()
            {
                InstanceId = request.InstanceId,
                Operand1 = request.Operand1,
                Operand2 = request.Operand2,
                Operator = request.Operator
            };

            var outputResult = CalculateEngine.CalculateResult(inputRequest);

            return new CalculatorData()
            {
                Value = outputResult.Result
            };
        }

        public void ClearTotal(CalculatorData calculatorData)
        {
            StorageAccessor.ClearStorageData(new StorageData()
            {
                InstanceId = calculatorData.InstanceId,
                Value = calculatorData.Value
            });
        }

        public CalculatorData LoadTotal(CalculatorData calculatorData)
        {
            return new CalculatorData()
            {
                InstanceId = calculatorData.InstanceId,
                Value = StorageAccessor.LoadStorageData(new StorageData()
                {
                    InstanceId = calculatorData.InstanceId,
                    Value = calculatorData.Value
                }).Value
            };
        }

        public void StoreToMemory(CalculatorData calculatorData)
        {
            CacheUtility.SaveToCache(new CacheData()
            {
                InstanceId = calculatorData.InstanceId,
                Value = calculatorData.Value
            });

        }

        public CalculatorData RetrieveFromMemory(CalculatorData calculatorData)
        {
            var cacheData = new CacheData()
            {
                InstanceId = calculatorData.InstanceId,
                Value = calculatorData.Value
            };

            return new CalculatorData()
            {
                InstanceId = calculatorData.InstanceId,
                Value = CacheUtility.RetrieveFromCache(cacheData).Value
            };

        }

        public void ClearMemory(CalculatorData calculatorData)
        {
            var cacheData = new CacheData()
            {
                InstanceId = calculatorData.InstanceId,
                Value = calculatorData.Value
            };

            CacheUtility.ClearCache(cacheData);

        }

    }
}
