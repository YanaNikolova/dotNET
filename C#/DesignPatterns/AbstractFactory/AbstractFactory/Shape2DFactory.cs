using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Shape2DFactory : IShapeFactory
    {
        public IShape CreateShape(int points)
        {
            switch (points)
            {
                case 0:
                    return new Circle();
                case 3:
                    return new Triangle();
                case 4:
                    return new Rectangle();
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
