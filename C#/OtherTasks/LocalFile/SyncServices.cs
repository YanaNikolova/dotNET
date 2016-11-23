using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK2PBCustomerImport.SyncServices.LocalFile
{
    class SyncServices : ISyncServices
    {
        private SyncData syncData;

        public SyncServices(SyncData syncData)
        {
            this.syncData = syncData;
        }

        public long GetSyncNumber()
        {
            return syncData.SyncNumber;
        }

        public void SaveSyncNumber(long number)
        {
            syncData.SyncNumber = number;
        }
    }
}
