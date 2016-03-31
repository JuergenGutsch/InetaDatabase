using System.Collections.Generic;
using System.Threading.Tasks;
using Gos.Tools.Azure;
using Gos.Tools.Cqs.Query;
using InetaAdmin.Database.Entities;
using InetaAdmin.Infrastructure.Read.Queries;

namespace InetaAdmin.Infrastructure.Read.QueryHandler
{
    public class UsergroupQueryHandler :
        IHandleQueryAsync<AllUsergroupsQuery, IEnumerable<Usergroup>>,
        IHandleQueryAsync<SingleUsergroupByIdQuery, Usergroup>
    {
        private readonly ITableClient _tableClient;

        public UsergroupQueryHandler(ITableClient tableClient)
        {
            _tableClient = tableClient;
        }

        public async Task<IEnumerable<Usergroup>> ExecuteAsync(AllUsergroupsQuery query)
        {
            var result = await _tableClient.GetItemsOf<Usergroup>();
            return result;
        }

        public async Task<Usergroup> ExecuteAsync(SingleUsergroupByIdQuery query)
        {
            var result = await _tableClient.GetItemOf<Usergroup>(query.Id);
            return result;
        }
    }

}