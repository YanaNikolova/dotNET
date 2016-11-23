using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ShapeGenerator
    {
        public IShapeContainer ShapeContainer { get; set;}

        public void CreateCircle(Point center, int radius, int NumberOfPoints) 
        {
            double delta = Math.PI / NumberOfPoints;
            double angle = 0;
            for (int i = 0; i < NumberOfPoints; i++)
            {
                double x = center.x + radius * Math.Cos(angle);
                double y = radius * Math.Sin(angle);
                Point p = new Point(x, center.y + y);
                ShapeContainer.Add(p);
                ShapeContainer.Add(new Point(x, center.y - y));
                angle += delta;
            }
        }

        public void CreatePoint(Point p)
        {
            ShapeContainer.Add(p);
        }

        public void CreateLine(Point p1, Point p2, int NumberOfPoints) {
            double a, b, dx, newX=0, newY=0;
            a = (p2.y - p1.y) / (p2.x - p1.x);
            b = ((p1.y * p2.x) - (p2.y * p1.x)) / (p2.x - p1.x);
            dx = (p2.x - p1.x) / NumberOfPoints;
            for (int i = 0; i < NumberOfPoints; i++)
            {
                newX += dx;
                newY = (a * newX) + b;
                ShapeContainer.Add(new Point(newX, newY));
            }
        }
    }
}
