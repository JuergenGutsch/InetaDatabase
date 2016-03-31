using System;
using Gos.Tools.Cqs.Query;
using InetaAdmin.Database.Entities;

namespace InetaAdmin.Infrastructure.Read.Queries
{
    public class SingleNewsletterByIdQuery : IQuery<Newsletter>
    {
        public SingleNewsletterByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}