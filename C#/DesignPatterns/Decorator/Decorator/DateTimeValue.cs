using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class DateTimeValue : IValue
    {
        public object Value { get; private set; }

        public DateTimeValue(DateTime val)
        {
            this.Value = val;
        }
    }
}
