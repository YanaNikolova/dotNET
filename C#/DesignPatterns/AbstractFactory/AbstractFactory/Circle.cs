using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Circle : IShape
    {
        public string Name()
        {
            return "Circle";
        }
    }
}
