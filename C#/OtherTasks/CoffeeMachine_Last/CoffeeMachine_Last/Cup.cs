using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Last
{
    class Cup
    {
        private int currentSubstanceInMls = 0;

        public void Add(int substanceInMls)
        {
            currentSubstanceInMls += substanceInMls;
        }
        private int Drink(int substanceInMls)
        {
            currentSubstanceInMls -= substanceInMls;
            return currentSubstanceInMls;
        }
        private int DrinkAll()
        {
            currentSubstanceInMls = 0;
            return currentSubstanceInMls;
        }
    }
}
