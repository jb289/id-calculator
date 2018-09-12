using Calculator.Common;
using Calculator.Common.Contracts;

namespace Calculator.Utilities
{
    public class UtilityFactory : FactoryBase
    {
        public UtilityFactory(AmbientContext context) : base(context)
        {
            // TODO: Register types here!
            RegisterType<ICacheUtility, MemoryCacheUtility>();
        }

        public T Create<T>() where T : class, IServiceBase
        {
            T result = Resolve<T>();
            UtilityBase baseUtility = result as UtilityBase;

            if (baseUtility != null)
                baseUtility.Context = Context;

            return result;
        }
    }
}
