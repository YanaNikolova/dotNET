using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.Add("first");
            list.Add("second");
            list.Insert("third");
            list.Add("4");
            //Console.WriteLine(list.RemoveFirst());
            //Console.WriteLine(list.RemoveFirst());
            //Console.WriteLine(list.RemoveFirst());
            //Console.WriteLine(list.RemoveFirst());
            //list.Clear();
            Console.WriteLine(list[2]);
            list[2] = 2;
            object obj = list[3];
            int x = (int)obj;
            Console.WriteLine(list.ToString());
            Console.ReadLine();
        }
    }
}