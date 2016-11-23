using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class EggContainer
    {
        public int TakeEggs(IBird obj)
        {
            return obj.GiveEggs();
        }
    }
}
