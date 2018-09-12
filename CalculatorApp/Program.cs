using System;
using System.Diagnostics;
using Calculator.Common.Contracts;
using Calculator.Engines;
using Calculator.Managers;

namespace Calculator.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var managerFactory = new ManagerFactory(new AmbientContext());

            var calculationManager = managerFactory.Create<ICalculationManager>();

            var instanceId = Guid.NewGuid();
            var currentTotal = new CalculatorData() {InstanceId = instanceId};
            var memoryTotal = new CalculatorData() {InstanceId = instanceId};

            double operand1 = 2.0006D;
            double operand2 = 3D;

            // Add two numbers
            Console.WriteLine($"Calculating {operand1} + {operand2}");
            var calculatorRequest = new CalculationRequest()
            {
                InstanceId = instanceId,
                Operand1 = operand1,
                Operand2 = operand2,
                Operator = "+"
            };
            var result = calculationManager.GetCalculationResult(calculatorRequest);

            // Get Total From Storage
            Console.WriteLine("Retrieving Total from storage");
            currentTotal = calculationManager.LoadTotal(currentTotal);
            Console.WriteLine($"Total from storage: {currentTotal.Value}");

            Debug.Assert(currentTotal.InstanceId == instanceId);
            Debug.Assert(currentTotal.Value.CompareTo(operand1 + operand2) == 0);

            // Store Total to Memory
            Console.WriteLine("Storing Total to memory");
            calculationManager.StoreToMemory(currentTotal);

            // Retrieve From Memory
            Console.WriteLine("Retreiving Total to memory");
            memoryTotal = calculationManager.RetrieveFromMemory(memoryTotal);

            Debug.Assert(memoryTotal.InstanceId == instanceId);
            Debug.Assert(memoryTotal.Value.CompareTo(currentTotal.Value) == 0);

            // Clear Memory
            Console.WriteLine("Clearing memory");
            calculationManager.ClearMemory(memoryTotal);

            // Clear Total From Storage
            Console.WriteLine("Clearing total storage");
            calculationManager.ClearTotal(new CalculatorData()
            {
                InstanceId = instanceId
            });

            Console.WriteLine("Press Enter to close");

            Console.ReadLine();

        }
    }
}
