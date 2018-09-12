using System;
using System.Collections.Generic;
using System.Diagnostics;
using Calculator.Common.Contracts;

namespace Calculator.Common
{
    public abstract class FactoryBase
    {
        #region Fields
        private readonly Dictionary<string, object> _overrides = new Dictionary<string, object>();
        private readonly Dictionary<string, Type> _types = new Dictionary<string, Type>();
        #endregion

        #region Constructors
        protected FactoryBase(AmbientContext context)
        {
            Context = context;
        }
        #endregion

        #region Properties
        public AmbientContext Context { get; private set; }
        #endregion

        #region Methods
        public void RegisterOverride<T>(T instance)
        {
            if (!_overrides.ContainsKey(typeof(T).Name))
                _overrides.Add(typeof(T).Name, instance);
        }

        public void RegisterType<TInterface, TImplementation>()
        {
            if (!_types.ContainsKey(typeof(TInterface).Name))
                RegisterType<TInterface>(typeof(TImplementation));
        }

        public void RegisterType<T>(Type type)
        {
            if (!_types.ContainsKey(typeof(T).Name))
                _types.Add(typeof(T).Name, type);
        }

        protected T Resolve<T>() where T : class, IServiceBase
        {
            string typeName = typeof(T).Name;

            if (_overrides.ContainsKey(typeName))
                return _overrides[typeName] as T;

            if (_types.ContainsKey(typeName))
            {
                Type type = _types[typeName] as Type;
                Debug.Assert(type != null);
                if (type != null)
                    return Activator.CreateInstance(type) as T;
            }

            throw new ArgumentException($"the Type {typeName} has not been registered in this factory.");
        }
        #endregion

    }
}
