using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK2PBCustomerImport.SyncServices.LocalFile
{
    class FileData
    {
        public SyncData SyncData { get; private set; }
        public BufferData BufferData { get; private set; }

        public FileData(SyncData syncData, BufferData bufferData)
        {
            this.SyncData = syncData;
            this.BufferData = bufferData;
        }
    }
}
