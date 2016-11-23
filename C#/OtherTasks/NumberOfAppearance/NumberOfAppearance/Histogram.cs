using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfAppearance
{
    class Histogram
    {

        public ICollection<int> CreateHistogram(IEnumerable<int> values)
        {
            List<int> occurrenceCount = new List<int>();
            for (int i = 0; i <= 10; i++)
            {
                occurrenceCount.Add(0);
            }
            foreach (int x in values)
            {
                occurrenceCount[x]++;
            }
            return occurrenceCount;
        }
    }
}
