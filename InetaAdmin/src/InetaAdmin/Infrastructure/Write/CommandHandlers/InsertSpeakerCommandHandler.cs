using Gos.Tools.Azure;
using Gos.Tools.Cqs.Command;
using InetaAdmin.Infrastructure.Write.Commands;

namespace InetaAdmin.Infrastructure.Write.CommandHandlers
{
    public class InsertSpeakerCommandHandler : ICommandHandler<InsertSpeakerCommand>
    {
        private readonly ITableClient _tableClient;

        public InsertSpeakerCommandHandler(ITableClient tableClient)
        {
            _tableClient = tableClient;
        }

        public void Handle(InsertSpeakerCommand command)
        {
            _tableClient.SaveItemOf(command.Value);
        }
    }
}