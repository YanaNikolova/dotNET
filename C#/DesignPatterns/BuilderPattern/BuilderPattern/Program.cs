using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var shapeContainer = new WindowsFormsShapeContainer.WinFormsShapeContainer();
            shapeContainer.MaxCoordinateValue = 1000;
            ShapeGenerator generator = new ShapeGenerator();
            generator.ShapeContainer = shapeContainer;
            Point myPoint = new Point(4, 8);
            Point myPointSecond = new Point(1500, 170);
            generator.CreatePoint(myPoint);
            generator.CreateCircle(myPoint, 450, 5000);
            generator.CreateLine(myPoint, myPointSecond, 700);
            shapeContainer.Draw();
            Console.ReadLine();
        }
    }
}
