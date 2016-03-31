using System;

namespace Gos.Tools.Azure
{
    public class StorageAccountCredentials
    {
        public string AccountName { get; set; }
        public Uri StorageUri { get; set; }
        public string KeyValue { get; set; }
    }
}