using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Last
{
    class CoffeeMachine
    {
        private int standardCoffeeVolumeInMls;
        private int largeCoffeeVolumeInMls;

        private CupModule cupModule = new CupModule();
        private SugarModule sugarModule = new SugarModule();
        private CoffeeModule coffeeModule;

        public CoffeeMachine(int coffeeVolumeInMls, int largeCoffeeVolumeInMls, int initialCoffeeInMachineInMls = 0)
        {
            this.standardCoffeeVolumeInMls = coffeeVolumeInMls;
            this.largeCoffeeVolumeInMls = largeCoffeeVolumeInMls;
            this.coffeeModule = new CoffeeModule(2000, initialCoffeeInMachineInMls);
        }

        public Cup GetCoffee(SugarLevel sugarLevel = SugarLevel.Default)
        {
            Cup c = cupModule.GetCup();
            sugarModule.AddSugar(c, sugarLevel);
            coffeeModule.AddCoffee(c, standardCoffeeVolumeInMls);
            return c;
        }

        public int LoadCups(int number)
        {
            return cupModule.LoadCups(number);
        }

        public void LoadSugar(int number)
        {
            sugarModule.LoadSugar(number);
        }

        public void LoadCoffee(int number)
        {
            coffeeModule.LoadCoffee(number);
        }

        public class CupModule
        {
            public readonly int MaxCups = 120;
            public int availableCups = 60; 

            public int AvailableCups
            {
                get { return availableCups; }
            }

            public int LoadCups(int cupsNumber)
            {
                if (cupsNumber == 0)
                {
                    availableCups = MaxCups;
                    return availableCups;
                }
                else {
                    int missingCups = MaxCups - availableCups;
                    if (cupsNumber > missingCups)
                    {
                        availableCups = MaxCups;
                        return missingCups;
                    }
                    else
                    {
                        availableCups += cupsNumber;
                        return cupsNumber;
                    }
                }
            }

            public Cup GetCup()
            {
                if (availableCups <= 0)
                {
                    throw new ArgumentException("No cups in the machine");
                }
                Cup cup = new Cup();
                availableCups--;
                return cup;
            }
        }

        public class SugarModule
        {
            public readonly int maxSugarInMls = 2000;
            public int availableSugarInMls = 1500;

            private SugarLevel sugar;

            public int AvailableSugar
            {
                get { return availableSugarInMls; }
            }

            public int LoadSugar(int sugarQuantity)
            {
                int missingSugar = maxSugarInMls - availableSugarInMls;
                if ( sugarQuantity == 0){
                    availableSugarInMls = maxSugarInMls;
                    return availableSugarInMls;
                }
                else
                {
                    if (sugarQuantity > missingSugar)
                    {
                        availableSugarInMls = maxSugarInMls;
                        return missingSugar;
                    }
                    else
                    {
                        availableSugarInMls += sugarQuantity;
                        return sugarQuantity;
                    }
                }
            }

            public void AddSugar(Cup cup, SugarLevel sugarLevel)
            {
                int sugarVolume = ResolveToVolumeInMls(sugarLevel);
                if (sugarVolume > availableSugarInMls)
                {
                    throw new ArgumentException("There is no sugar in the machine.");
                }
                availableSugarInMls -= sugarVolume;
                cup.Add(sugarVolume);
            }

            public int ResolveToVolumeInMls(SugarLevel x) {
                switch (x)
                {
                    case SugarLevel.None:
                        return 0;
                    case SugarLevel.Small:
                        return 2;
                    case SugarLevel.Default:
                        return 4;
                    case SugarLevel.Middle:
                        return 6;
                    case SugarLevel.Large:
                        return 8;
                    case SugarLevel.XtraLarge:
                        return 10;
                    default:
                        return 4;
                }
            } 
        }

        public class CoffeeModule
        {
            private readonly int maxCoffeeInMls;
            public int availableCoffeeInMls;

            public CoffeeModule(int maxCoffeeInMls, int initialCoffeeInMls)
            {
                this.maxCoffeeInMls = maxCoffeeInMls;
                this.availableCoffeeInMls = initialCoffeeInMls;
            }

            public int LoadCoffee(int coffeeQuantity)
            {
                int missingCoffee = maxCoffeeInMls - availableCoffeeInMls;
                if (coffeeQuantity == 0)
                {
                    availableCoffeeInMls = maxCoffeeInMls;
                    return availableCoffeeInMls;
                }
                else
                {
                    if (coffeeQuantity > missingCoffee)
                    {
                        availableCoffeeInMls = maxCoffeeInMls;
                        return missingCoffee;
                    }
                    else
                    {
                        availableCoffeeInMls += coffeeQuantity;
                        return coffeeQuantity;
                    }
                }
            }

            public void AddCoffee(Cup cup, int coffeeVolumeInMls)
            {
                if (availableCoffeeInMls < coffeeVolumeInMls)
                {
                    throw new CoffeeException();
                }
                availableCoffeeInMls -= coffeeVolumeInMls;
                cup.Add(coffeeVolumeInMls);
            }
        }

        public void CheckSugar(int sugarVolume, int availableSugarInMls){
            if( sugarVolume > availableSugarInMls ){
                throw new SugarException();
            }
        }

        public void CheckCoffee(int availableCoffeeInMls){
            if(availableCoffeeInMls <= 0){
                throw new CoffeeException();
            }
        }

        public void CheckCups(int availableCups){
            if (availableCups <= 0)
            {
                throw new CupException();
            }
        }

        public class CoffeeException : Exception
        {
        }

        public class SugarException : Exception
        {
        }

        public class CupException : Exception
        {
        }
       
    }
}
