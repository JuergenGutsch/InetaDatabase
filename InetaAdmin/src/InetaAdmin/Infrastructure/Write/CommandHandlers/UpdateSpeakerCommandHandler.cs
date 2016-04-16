using Gos.Tools.Azure;
using Gos.Tools.Cqs.Command;
using InetaAdmin.Infrastructure.Write.Commands;

namespace InetaAdmin.Infrastructure.Write.CommandHandlers
{
    public class UpdateSpeakerCommandHandler : ICommandHandler<UpdateSpeakerCommand>
    {
        private readonly ITableClient _tableClient;

        public UpdateSpeakerCommandHandler(ITableClient tableClient)
        {
            _tableClient = tableClient;
        }

        public void Handle(UpdateSpeakerCommand command)
        {
            _tableClient.SaveItemOf(command.Value);
        }
    }
}