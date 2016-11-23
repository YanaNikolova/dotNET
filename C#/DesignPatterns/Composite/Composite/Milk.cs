using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Milk : IDrink
    {
        public int milkQuantity { get; private set; }

        public Milk(int MilkQuantity)
        {
            this.milkQuantity = MilkQuantity;
        }

        public int Drink()
        {
            return milkQuantity = 0;
        }
    }
}
