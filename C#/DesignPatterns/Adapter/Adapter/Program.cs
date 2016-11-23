using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adapter
{
    static class Program
    {
        static void Main()
        {
            TurkeyBird ttb = new TurkeyBird(new Turkey(50));
            EggContainer container = new EggContainer();
            container.TakeEggs(ttb);
        }
    }
}
