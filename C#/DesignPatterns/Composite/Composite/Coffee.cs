using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Coffee : IDrink
    {
        public int coffeeQuantity { get; private set; }

        public Coffee(int CoffeeQuantity)
        {
            this.coffeeQuantity = CoffeeQuantity;
        }

        public int Drink()
        {
            return coffeeQuantity = 0;
        }
    }
}
