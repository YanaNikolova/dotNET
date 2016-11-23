using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfAppearance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> values = new List<int>() { 1, 0, 3, 5, 2, 6, 8, 10, 3, 9, 0, 2, 7, 7, 1, 3, 7, 0, 3, 8, 9, 3, 10, 2, 5, 10, 7, 9, 4, 3 };
            Histogram h = new Histogram();
            ICollection<int> histogram = h.CreateHistogram(values);
            Console.WriteLine(histogram);
            Console.ReadLine();
        }
    }
}
