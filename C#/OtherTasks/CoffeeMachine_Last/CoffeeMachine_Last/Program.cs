using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Last
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                CoffeeMachine coffeeMachine = new CoffeeMachine(coffeeVolumeInMls: 50, largeCoffeeVolumeInMls: 100, initialCoffeeInMachineInMls: 20);
                coffeeMachine.LoadCups(85);
                coffeeMachine.LoadCoffee(10);
                coffeeMachine.GetCoffee();
            }
            catch (CoffeeMachine.SugarException e)
            {
                Console.WriteLine("There is no sugar in the machine");
            }
            catch (CoffeeMachine.CoffeeException e)
            {
                Console.WriteLine("There is no coffee in the machine");
            }
            catch (CoffeeMachine.CupException e)
            {
                Console.WriteLine("There are no cups in the machine");
            }
            finally
            {
                Console.WriteLine("END");
            }
            Console.ReadLine();
        }
    }
}
