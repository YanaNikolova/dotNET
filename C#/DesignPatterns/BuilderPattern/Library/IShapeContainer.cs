using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public interface IShapeContainer
    {
        IShapeContainer Add(Point p);

        IShapeContainer Add(Point[] point);

        void Draw();

        void Clear();
    }
}
