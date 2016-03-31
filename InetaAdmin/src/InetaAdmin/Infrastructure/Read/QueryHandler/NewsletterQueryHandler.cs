using System.Collections.Generic;
using System.Threading.Tasks;
using Gos.Tools.Azure;
using Gos.Tools.Cqs.Query;
using InetaAdmin.Database.Entities;
using InetaAdmin.Infrastructure.Read.Queries;

namespace InetaAdmin.Infrastructure.Read.QueryHandler
{
    public class NewsletterQueryHandler :
        IHandleQueryAsync<AllNewslettersQuery, IEnumerable<Newsletter>>,
        IHandleQueryAsync<SingleNewsletterByIdQuery, Newsletter>
    {
        private readonly ITableClient _tableClient;

        public NewsletterQueryHandler(ITableClient tableClient)
        {
            _tableClient = tableClient;
        }

        public async Task<IEnumerable<Newsletter>> ExecuteAsync(AllNewslettersQuery query)
        {
            var result = await _tableClient.GetItemsOf<Newsletter>();
            return result;
        }

        public async Task<Newsletter> ExecuteAsync(SingleNewsletterByIdQuery query)
        {
            var result = await _tableClient.GetItemOf<Newsletter>(query.Id);
            return result;
        }
    }
}