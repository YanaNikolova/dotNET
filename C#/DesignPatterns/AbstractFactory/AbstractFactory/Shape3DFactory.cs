using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Shape3DFactory : IShapeFactory
    {
       public IShape CreateShape(int points)
        {
            switch (points)
            {
                case 0:
                    return new Cylinder();
                case 3:
                    return new Pyramid();
                case 4:
                    return new Cube();
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
