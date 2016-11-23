using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK2PBCustomerImport.SyncServices.LocalFile
{
    class LocalFileStorage
    {
        private readonly string fileURI;

        FileData fileData;

        public LocalFileStorage(FileData fileData)
        {
            this.fileData = fileData;
        }

        void LocateFile(string fileName, string filePath = null)
        {
            if (String.IsNullOrEmpty(filePath))
                filePath = AppDomain.CurrentDomain.BaseDirectory;
           // fileURI = String.Format("{0}/{1}", filePath, fileName);
        }
        void GetData()
        {
        }

        void SaveData()
        {
        }
    }
}
