using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();
            queue.Add("1");
            queue.Add("2");
            queue.Add("3");
            queue.Add("4");
            queue.Add("5");
            Console.WriteLine(queue.RemoveFirst());
            Console.WriteLine(queue.RemoveFirst());
            Console.WriteLine(queue.RemoveFirst());
            Console.WriteLine(queue.RemoveFirst());
            Console.WriteLine(queue.RemoveFirst());
            queue.Clear();
            int count = queue.Count;
            Console.ReadLine();
        }
    }
}
