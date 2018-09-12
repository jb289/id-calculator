using Calculator.Accessors;
using Calculator.Common;
using Calculator.Utilities;

namespace Calculator.Engines
{
    public abstract class EngineBase : ServiceBase
    {
        internal AccessorFactory AccessorFactory { get; set; }
        internal UtilityFactory UtilityFactory { get; set; }

        protected EngineBase()
        {
        }
    }
}
