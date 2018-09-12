using System;
using Calculator.Accessors;
using Calculator.Common;
using Calculator.Common.Contracts;
using Calculator.Utilities;

namespace Calculator.Engines
{
    public class EngineFactory : FactoryBase
    {
        public EngineFactory(AmbientContext context) : base(context)
        {
            // TODO: Register types here!
            RegisterType<ICalculateEngine, CalculateEngine>();

        }

        public T Create<T>() where T : class, IServiceBase
        {
            return Create<T>(null, null);
        }

        public T Create<T>(AccessorFactory accessorFactory, UtilityFactory utilityFactory) where T : class, IServiceBase
        {
            if (Context == null)
                throw new InvalidOperationException("Context cannot be null.");

            T engine = base.Resolve<T>();

            EngineBase engineBase = engine as EngineBase;
            if (engineBase == null)
                throw new InvalidOperationException($"{typeof(T).Name} does not implement EngineBase.");

            engineBase.Context = Context;
            engineBase.AccessorFactory = accessorFactory ?? new AccessorFactory(Context);
            engineBase.UtilityFactory = utilityFactory ?? new UtilityFactory(Context);

            return engine;
        }
    }
}
