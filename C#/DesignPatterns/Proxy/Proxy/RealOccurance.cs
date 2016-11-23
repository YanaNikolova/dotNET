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
    class RealOccurance : IOccurance
    {
        public IDictionary<string, int> NumberOfOccurances()
        {
            string[] fileLines = File.ReadAllLines("c:/users/yana/documents/visual studio 2013/Projects/Proxy/Proxy/NumbersFile.txt");
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (var singleLine in fileLines)
            {
                if (dict.ContainsKey(singleLine))
                {
                    dict[singleLine] += 1;
                }
                else
                {
                    dict.Add(singleLine, 1);
                }
            }
            return dict;
        }
    }
}
