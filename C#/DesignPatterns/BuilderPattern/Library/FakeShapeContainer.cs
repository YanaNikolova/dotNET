using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class FakeShapeContainer : IShapeContainer
    {
        public void Draw() { }
        public void Clear() { }
        public IShapeContainer Add(Point p) {
            return this;
        }


        public IShapeContainer Add(Point[] point)
        {
            return this;
        }
    }
}
