using System;
using Gos.Tools.Cqs.Query;
using InetaAdmin.Database.Entities;

namespace InetaAdmin.Infrastructure.Read.Queries
{
public class SpeakerByIdQuery : IQuery<Speaker>
{
    public SpeakerByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}
}