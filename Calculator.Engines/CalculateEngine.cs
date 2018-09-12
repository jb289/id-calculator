using System;
using System.Collections.Generic;
using System.Text;
using Calculator.Accessors;
using Calculator.Common;

namespace Calculator.Engines
{
    public class CalculateEngine : EngineBase, ICalculateEngine
    {

        private readonly IStorageAccessor _fileSystemAccessor = null;
        private IStorageAccessor FileSystemAccessor => _fileSystemAccessor ?? base.AccessorFactory.Create<IStorageAccessor>();

        public CalculateEngine()
        {
        }

        public CalculateResultResult CalculateResult(CalculateResultRequest request)
        {
            var result = new CalculateResultResult()
            {
                Result = request.Operand1 + request.Operand2
            };

            FileSystemAccessor.SetStorageData(new StorageData()
            {
                InstanceId = request.InstanceId,
                Value = result.Result
            });

            return result;
        }
    }
}
