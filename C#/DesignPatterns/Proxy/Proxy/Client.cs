using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    class Client
    {
        static void Main(string[] args)
        {
            ProxyOccurance p = new ProxyOccurance();
            p.NumberOfOccurances();
            Thread.Sleep(10000);
            p.NumberOfOccurances();
            Thread.Sleep(10000);
            p.NumberOfOccurances();
            Console.ReadLine();
        }
    }
}
