using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            DecimalValue val1 = new DecimalValue(12345);
            DateTimeValue val2 = new DateTimeValue(DateTime.Now);
            FormattedValue f = new FormattedValue(val1);
            FormattedValue f2 = new FormattedValue(val2);
            f.Format("{0:0 000.00}");
            f2.Format("{0:yyyy-MM-dd}");
            Console.WriteLine(f.Value);
            Console.WriteLine(f2.Value);
            Console.ReadLine();
        }
    }
}
