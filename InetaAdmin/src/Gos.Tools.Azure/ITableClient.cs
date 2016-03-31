using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gos.Tools.Azure
{
    public interface ITableClient
    {
        void SaveItemOf<T>(T item) where T : IItem, new();
        void SaveAllItemsOf<T>(IEnumerable<T> item) where T : IItem, new();

        Task<T> GetItemOf<T>(Guid id) where T : IItem, new();
        Task<IEnumerable<T>> GetItemsOf<T>() where T : IItem, new();
        void DeleteItemOf<T>(T item) where T : IItem, new();
    }
}