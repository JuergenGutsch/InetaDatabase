using System.Collections.Generic;
using System.Threading.Tasks;
using Gos.Tools.Azure;
using Gos.Tools.Cqs.Query;
using InetaAdmin.Database.Entities;
using InetaAdmin.Infrastructure.Read.Queries;

namespace InetaAdmin.Infrastructure.Read.QueryHandler
{
    public class EventQueryHandler :
        IHandleQueryAsync<AllEventsQuery, IEnumerable<Event>>,
        IHandleQueryAsync<SingleEventByIdQuery, Event>
    {
        private readonly ITableClient _tableClient;

        public EventQueryHandler(ITableClient tableClient)
        {
            _tableClient = tableClient;
        }

        public async Task<IEnumerable<Event>> ExecuteAsync(AllEventsQuery query)
        {
            var result = await _tableClient.GetItemsOf<Event>();
            return result;
        }

        public async Task<Event> ExecuteAsync(SingleEventByIdQuery query)
        {
            var result = await _tableClient.GetItemOf<Event>(query.Id);
            return result;
        }
    }
}