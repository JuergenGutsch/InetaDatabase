using System;
using Gos.Tools.Cqs.Command;

namespace InetaAdmin.Infrastructure.Write.Commands
{
    public class DeleteSpeakerCommand : ICommand
    {
        public Guid Id { get; private set; }

        public DeleteSpeakerCommand(Guid id)
        {
            Id = id;
        }
    }
}