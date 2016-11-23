using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK2PBCustomerImport.SyncServices.LocalFile
{
    class CustomerIDNumberPairsBuffer : ICustomerIDNumberPairsBuffer
    {
        private List<CustomerIDNumberPair> customerIDNumberPairs;

        public void Add(IEnumerable<CustomerIDNumberPair> pairs)
        {
            customerIDNumberPairs.AddRange(pairs);
        }

        public IEnumerable<CustomerIDNumberPair> All()
        {
            return customerIDNumberPairs;
        }

        public void Clear()
        {
            customerIDNumberPairs.Clear();
        }
    }
}
