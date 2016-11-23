using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class B
    {
        public int Value { get; set; }

        public B Clone()
        {
            return new B
            {
                Value = this.Value
            };
        }
    }
}
