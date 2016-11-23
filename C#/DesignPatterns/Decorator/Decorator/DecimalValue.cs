using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class DecimalValue : IValue
    {
        public object Value { get; private set; }

        public DecimalValue(decimal val)
        {
            this.Value = val;
        }
    }
}
