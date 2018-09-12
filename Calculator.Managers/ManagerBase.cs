using Calculator.Accessors;
using Calculator.Common;
using Calculator.Common.Contracts;
using Calculator.Engines;
using Calculator.Utilities;

namespace Calculator.Managers
{
    public abstract class ManagerBase : ServiceBase 
    {
        internal EngineFactory EngineFactory { get; set; }
        internal AccessorFactory AccessorFactory { get; set; }
        internal UtilityFactory UtilityFactory { get; set; }

        protected ManagerBase()
        {
        }

    }
}
