using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class ProxyOccurance : IOccurance
    {
        IDictionary<string, int> cachedResult = null;

        RealOccurance realObject = new RealOccurance();
        Stopwatch sw = new Stopwatch();

        public IDictionary<string, int> NumberOfOccurances()
        {
            sw.Stop();
            if ( sw.ElapsedMilliseconds <= 15000 && cachedResult != null )
            {
                sw.Start();
                return new Dictionary<string, int>(cachedResult);
            }
            else
            {
                cachedResult = realObject.NumberOfOccurances();
                sw.Restart();
                return new Dictionary<string, int>(cachedResult);
            }
        }
    }
}
