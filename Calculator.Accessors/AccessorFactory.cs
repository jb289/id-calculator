using System;
using Calculator.Common;
using Calculator.Common.Contracts;
using Calculator.Utilities;

namespace Calculator.Accessors
{
    public class AccessorFactory : FactoryBase
    {
        public AccessorFactory(AmbientContext context) : base(context)
        {
            // TODO: Register types here!
            RegisterType<IStorageAccessor, FileSystemAccessor>();

        }

    public T Create<T>() where T : class, IServiceBase
        {
            return Create<T>(null);
        }

        public T Create<T>(UtilityFactory utilityFactory) where T : class, IServiceBase
        {
            if (Context == null)
                throw new InvalidOperationException("Context cannot be null.");

            T accessor = base.Resolve<T>();

            AccessorBase accessorBase = accessor as AccessorBase;
            if (accessorBase == null)
                throw new InvalidOperationException($"{typeof(T).Name} does not implement AccessorBase.");

            accessorBase.Context = Context;
            accessorBase.UtilityFactory = utilityFactory ?? new UtilityFactory(Context);

            return accessor;
        }
    }
}
