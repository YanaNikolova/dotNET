using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    interface IShapeContainer
    {
        IShapeContainer Add(Point p);
        IShapeContainer Add(Point[] points);
        void Draw();
        void Clear();

    }
}
