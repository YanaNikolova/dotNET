using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;

namespace WindowsFormsShapeContainer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MaxCoordinateValue = 100d;
        }

        public void Draw(ICollection<Library.Point> points)
        {
            this.points = points;
            this.Refresh();
        }

        public double MaxCoordinateValue { get; set; }

        private ICollection<Library.Point> points;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (points != null)
            {
                int xCenter = this.Width / 2;
                int yCenter = this.Height / 2;
                int size = xCenter <= yCenter ? xCenter : yCenter;
                double scale = size / MaxCoordinateValue;
                Brush brush = System.Drawing.Brushes.Black;
                foreach (var p in points)
                {
                    int x = xCenter + (int)(scale * p.x);
                    int y = yCenter - (int)(scale * p.y);
                    e.Graphics.FillRectangle(brush, x, y, 2, 2);
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        } 
    }
}
