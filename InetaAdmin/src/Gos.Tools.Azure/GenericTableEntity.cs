using Microsoft.WindowsAzure.Storage.Table;

namespace Gos.Tools.Azure
{
    public class GenericTableEntity: TableEntity
    {
        public string Item { get; set; }
        public string ItemType { get; set; }
    }
}
