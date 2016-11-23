using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class ShapeFactories
    {
        private IShapeFactory shapeFactory2D = new Shape2DFactory();
        private IShapeFactory shapeFactory3D = new Shape3DFactory();

        public IShapeFactory GetShapeFactory(bool is2D)
        {
           // return is2D ? shapeFactory2D : shapeFactory3D;
            if (is2D)
            {
                return new Shape2DFactory();
            }
            else
            {
                return new Shape3DFactory();
            }
        }
    }
}
