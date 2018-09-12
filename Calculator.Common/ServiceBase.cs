using System;
using Calculator.Common.Contracts;

namespace Calculator.Common
{
    public abstract class ServiceBase : IServiceBase
    {
        public AmbientContext Context { get; set; }

        public virtual string TestMe(string input)
        {
            string result = $"{input} : {GetType().Name}";
            Console.WriteLine(result);
            return result;
        }
    }
}
