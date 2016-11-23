using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK2PBCustomerImport.SyncServices.LocalFile
{
    class BufferData
    {
        public List<CustomerIDNumberPair> CustomerIDNumberPairs { get; private set; }
        
        public BufferData(List<CustomerIDNumberPair> customerIDNumberPairs)
        {
            this.CustomerIDNumberPairs = customerIDNumberPairs;
        }
    }
}
