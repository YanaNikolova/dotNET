using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Composite
{
    static class Program
    {
        static void Main()
        {
            Milk milk = new Milk(30);
            Coffee coffee = new Coffee(30);
            milk.Drink();
            coffee.Drink();
            CoffeeWithMilk cwithMilk = new CoffeeWithMilk(new Milk(25), new Coffee(25));
            cwithMilk.Drink();
            Console.ReadLine();
        }
    }
}
