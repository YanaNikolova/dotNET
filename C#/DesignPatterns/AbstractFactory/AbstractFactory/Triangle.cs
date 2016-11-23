using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Triangle : IShape
    {
        public string Name()
        {
            return "Triangle";
        }
    }
}
