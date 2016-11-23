using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Rectangle:IShape
    {
        public string Name()
        {
            return "Rectangle";
        }
    }
}
