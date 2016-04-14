using System.Collections.Generic;
using System.Threading.Tasks;
using Gos.Tools.Azure;
using Gos.Tools.Cqs.Query;
using InetaAdmin.Database.Entities;
using InetaAdmin.Infrastructure.Read.Queries;

namespace InetaAdmin.Infrastructure.Read.QueryHandler
{
    public class SpeakerQueryHandler :
        IHandleQueryAsync<AllSpeakersQuery, IEnumerable<Speaker>>,
        IHandleQueryAsync<SpeakerByIdQuery, Speaker>
    {
        private readonly ITableClient _tableClient;

        public SpeakerQueryHandler(ITableClient tableClient)
        {
            _tableClient = tableClient;
        }

        public async Task<IEnumerable<Speaker>> ExecuteAsync(AllSpeakersQuery query)
        {
            var result = await _tableClient.GetItemsOf<Speaker>();
            return result;
        }

        public async Task<Speaker> ExecuteAsync(SpeakerByIdQuery query)
        {
            var result = await _tableClient.GetItemOf<Speaker>(query.Id);
            return result;
        }
    }
}
