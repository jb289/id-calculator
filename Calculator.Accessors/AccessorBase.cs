using Calculator.Common;
using Calculator.Utilities;

namespace Calculator.Accessors
{
    public abstract class AccessorBase : ServiceBase
    {
        internal UtilityFactory UtilityFactory { get; set; }

        protected AccessorBase()
        {
        }
    }
}
