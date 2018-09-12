using System;
using Calculator.Accessors;
using Calculator.Common;
using Calculator.Common.Contracts;
using Calculator.Engines;
using Calculator.Utilities;

namespace Calculator.Managers
{
    public class ManagerFactory : FactoryBase
    {
        public ManagerFactory(AmbientContext context) : base(context)
        {
            // TODO: Register types here!
            RegisterType<ICalculationManager, CalculationManager>();

        }

        public T Create<T>() where T : class, IServiceBase
        {
            return Create<T>(null, null, null);
        }

        public T Create<T>(EngineFactory engineFactory, AccessorFactory accessorFactory, UtilityFactory utilityFactory) where T : class, IServiceBase
        {
            if (Context == null)
                throw new InvalidOperationException("Context cannot be null.");

            T manager = Resolve<T>();

            ManagerBase managerBase = manager as ManagerBase;
            if (managerBase == null)
                throw new InvalidOperationException($"{typeof(T).Name} does not implement ManagerBase.");

            managerBase.Context = Context;
            managerBase.EngineFactory = engineFactory ?? new EngineFactory(Context);
            managerBase.UtilityFactory = utilityFactory ?? new UtilityFactory(Context);
            managerBase.AccessorFactory = accessorFactory ?? new AccessorFactory(Context);

            return manager;
        }
    }
}
