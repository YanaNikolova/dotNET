using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class FormattedValue : IValue
    {
        private IValue value;

        public object Value 
        {
            get { return String.Format(Format, value.Value); }
        }

        public FormattedValue(IValue obj){
            this.value = obj;
        }

        public string Format { get; set; }
    }
}
