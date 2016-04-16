using System;
using Gos.Tools.Cqs.Command;
using InetaAdmin.Database.Entities;

namespace InetaAdmin.Infrastructure.Write.Commands
{
    public class UpdateSpeakerCommand : ICommand
    {
        public Guid Id { get; private set; }
        public Speaker Value { get; private set; }

        public UpdateSpeakerCommand(Guid id, Speaker value)
        {
            Id = id;
            Value = value;
        }
    }
}