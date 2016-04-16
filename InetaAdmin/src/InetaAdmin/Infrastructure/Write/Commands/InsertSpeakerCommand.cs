using Gos.Tools.Cqs.Command;
using InetaAdmin.Database.Entities;

namespace InetaAdmin.Infrastructure.Write.Commands
{
    public class InsertSpeakerCommand : ICommand
    {
        public Speaker Value { get; private set; }

        public InsertSpeakerCommand(Speaker value)
        {
            Value = value;
        }
    }
}