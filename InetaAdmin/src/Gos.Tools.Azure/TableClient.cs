using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

namespace Gos.Tools.Azure
{
    public class TableClient : ITableClient
    {
        private readonly CloudTableClient _cloudTableClient;

        public TableClient(StorageAccountCredentials storageAccountCredentials)
        {
            var credentials = new StorageCredentials(storageAccountCredentials.AccountName, storageAccountCredentials.KeyValue);
            _cloudTableClient = new CloudTableClient(storageAccountCredentials.StorageUri, credentials);
        }

        public async void SaveItemOf<T>(T item) where T : IItem, new()
        {
            var itemType = typeof(T);
            var table = await CloudTable<T>(itemType);

            var entity = new GenericTableEntity
            {
                RowKey = item.Id.ToString(),
                PartitionKey = itemType.Name,
                ItemType = itemType.FullName,
                Item = JsonConvert.SerializeObject(item)
            };

            var operation = TableOperation.InsertOrReplace(entity);
            var result = await table.ExecuteAsync(operation);
        }

        private async Task<CloudTable> CloudTable<T>(Type itemType) where T : IItem, new()
        {
            var table = _cloudTableClient.GetTableReference(itemType.Name);
            await table.CreateIfNotExistsAsync();
            return table;
        }

        public async void SaveAllItemsOf<T>(IEnumerable<T> items) where T : IItem, new()
        {
            var itemType = typeof(T);
            var table = await CloudTable<T>(itemType);

            var entities = items.Select(item => new GenericTableEntity
            {
                RowKey = item.Id.ToString(),
                PartitionKey = itemType.Name,
                ItemType = itemType.FullName,
                Item = JsonConvert.SerializeObject(item)
            });

            var batchOperation = new TableBatchOperation();
            entities.ForEach(entity =>
            {
                batchOperation.Add(TableOperation.InsertOrReplace(entity));
            });


            var result = await table.ExecuteBatchAsync(batchOperation);
        }

        public async Task<T> GetItemOf<T>(Guid id) where T : IItem, new()
        {
            var itemType = typeof(T);
            var table = await CloudTable<T>(itemType);

            var query = new TableQuery<GenericTableEntity>()
            {
                 FilterString = $"PartitionKey eq '{itemType.Name}' and RowKey eq '{id.ToString()}'"
            };

            var entity = (await table.ExecuteQuerySegmentedAsync(query, new TableContinuationToken())).FirstOrDefault();
            if (entity != null)
            {
                var item = JsonConvert.DeserializeObject<T>(entity.Item);
                return item;
            }

            return default(T);
        }

        public async Task<IEnumerable<T>> GetItemsOf<T>() where T : IItem, new()
        {
            var itemType = typeof(T);
            var table = await CloudTable<T>(itemType);

            var query = new TableQuery<GenericTableEntity>()
            {
                FilterString = $"PartitionKey eq '{itemType.Name}'"
            };
            var result = await table.ExecuteQuerySegmentedAsync(query, new TableContinuationToken());

            var items = new List<T>();
            result.ForEach(entity =>
            {
                var item = JsonConvert.DeserializeObject<T>(entity.Item);
                items.Add(item);
            });

            return items;
        }

        public async void DeleteItemOf<T>(T item) where T : IItem, new()
        {
            var itemType = typeof(T);
            var table = await CloudTable<T>(itemType);

            var tableItem = new GenericTableEntity
            {
                RowKey = item.Id.ToString(),
                PartitionKey = itemType.Name,
                ItemType = itemType.FullName,
                Item = JsonConvert.SerializeObject(item)
            };

            var operation = TableOperation.Delete(tableItem);
            var result = await table.ExecuteAsync(operation);

        }
    }
}
