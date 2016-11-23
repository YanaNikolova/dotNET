using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class Turkey
    {
        int eggs;

        public Turkey(int Eggs)
        {
            this.eggs = Eggs;
        }

        public int GiveEggs()
        {
            int givenEggs = eggs;
            eggs = 0;
            return givenEggs;
        }
    }
}
