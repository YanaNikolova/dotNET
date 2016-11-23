using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsShapeContainer
{
    public class WinFormsShapeContainer : IShapeContainer
    {
        private List<Point> points = new List<Point>();

        public double MaxCoordinateValue { get; set; }

        public void Draw()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 f = new Form1();
            if (MaxCoordinateValue != 0)
                f.MaxCoordinateValue = MaxCoordinateValue;
            f.Draw(points);
            Application.Run(f);
        }

        public IShapeContainer Add(Point p)
        {
            points.Add(p);
            return this;
        }

        public IShapeContainer Add(Point[] points)
        {
            this.points.AddRange(points);
            return this;
        }

        public void Clear()
        {
            points.Clear();
        }
    }
}
