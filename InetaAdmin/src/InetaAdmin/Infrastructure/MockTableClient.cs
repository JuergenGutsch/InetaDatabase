using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenFu;
using Gos.Tools.Azure;
using InetaAdmin.Database.Entities;

namespace InetaAdmin.Infrastructure
{
    public class MockTableClient : ITableClient
    {
        private readonly IDictionary<string, IEnumerable<IItem>> _db = new Dictionary<string, IEnumerable<IItem>>();

        public MockTableClient()
        {
            _db.Add(nameof(Speaker), A.ListOf<Speaker>(50));
            _db.Add(nameof(Usergroup), A.ListOf<Usergroup>(50));
            _db.Add(nameof(Event), A.ListOf<Event>(50));
            _db.Add(nameof(Newsletter), A.ListOf<Newsletter>(50));
        }

        public void SaveItemOf<T>(T item) where T : IItem, new()
        {
            var items = _db[typeof(T).Name];

            if (items.Any(x => x.Id.Equals(item.Id)))
            {
                ((List<IItem>)items).RemoveAll(x => x.Id.Equals(item.Id));
                ((List<IItem>)items).Add(item);
            }
            else
            {
                ((List<IItem>)items).Add(item);
            }
        }

        public void SaveAllItemsOf<T>(IEnumerable<T> items) where T : IItem, new()
        {
            foreach (var item in items)
            {
                SaveItemOf(item);
            }
        }

        public Task<T> GetItemOf<T>(Guid id) where T : IItem, new()
        {
            var items = _db[typeof(T).Name];
            var item = items.First(x => x.Id.Equals(id));
            return Task.FromResult((T)item);
        }

        public Task<IEnumerable<T>> GetItemsOf<T>() where T : IItem, new()
        {
            var items = _db[typeof(T).Name].Select(x => (T)x);
            return Task.FromResult(items);
        }

        public void DeleteItemOf<T>(T item) where T : IItem, new()
        {
            var items = _db[typeof(T).Name];
            ((List<IItem>)items).RemoveAll(x => x.Id.Equals(item.Id));
        }
    }
}