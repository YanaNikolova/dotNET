using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class TurkeyBird : IBird
    {
        private Turkey turkey;

        public TurkeyBird(Turkey turkey)
        {
            this.turkey = turkey;
        }

        public int GiveEggs()
        {
            return turkey.GiveEggs();
        }
    }
}
