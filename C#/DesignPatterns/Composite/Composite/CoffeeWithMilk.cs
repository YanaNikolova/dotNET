using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class CoffeeWithMilk : IDrink
    {
        public Milk milk;
        private Coffee coffee;
         
        int coffeeWithMilkQuantity = 0;

        public CoffeeWithMilk(Milk milk, Coffee coffee)
        {
            this.coffeeWithMilkQuantity = (milk.milkQuantity + coffee.coffeeQuantity);
        }

        public int Drink()
        {
            return coffeeWithMilkQuantity = 0;
        }
    }
}
