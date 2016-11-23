using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IShape> shapes = new List<IShape>();
            ShapeFactories factorySelector = new ShapeFactories();
            IShapeFactory st = factorySelector.GetShapeFactory(true);
            shapes.Add(st.CreateShape(4));
            shapes.Add(st.CreateShape(0));
            shapes.Add(st.CreateShape(3));

            IShapeFactory sf = factorySelector.GetShapeFactory(false);

            shapes.Add(sf.CreateShape(4));
            shapes.Add(sf.CreateShape(0));
            shapes.Add(sf.CreateShape(3));

            foreach (var item in shapes)
            {
                Console.WriteLine(item.Name());
            }

            Console.ReadLine();
        }
    }
}
