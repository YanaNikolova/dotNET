using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class A
    {
        public int age { get; set; }
        string str { get; set; }

        B item { get; set; }

        public A ShallowClone()
        {
            A result = new A();
            age = this.age;
            str = this.str;
            result.item = this.item;
            return result;
        }

        public A DeepClone()
        {
            return new A
            {
                age = this.age,
                str = this.str,
                item = item.Clone()
            };
        }
    }
}
