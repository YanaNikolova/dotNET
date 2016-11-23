using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            stack.Add(1).Add("jhfggfkyg").Add(3);
            stack.Clear();
            Console.WriteLine(stack.Count);
            Console.ReadLine();
        }
    }
}
