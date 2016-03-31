using System;
using Gos.Tools.Cqs.Query;
using InetaAdmin.Database.Entities;

namespace InetaAdmin.Infrastructure.Read.Queries
{
    public class SingleUsergroupByIdQuery : IQuery<Usergroup>
    {
        public SingleUsergroupByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}