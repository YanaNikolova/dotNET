using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class FakeShapeContainer : IShapeContainer
    {
        void Draw() { }

        void Clear() { }

        IShapeContainer Add(Point p) {
            return this;
        }

    }
}
