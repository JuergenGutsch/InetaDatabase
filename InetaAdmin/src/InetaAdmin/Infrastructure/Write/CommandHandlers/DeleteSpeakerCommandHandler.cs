using Gos.Tools.Azure;
using Gos.Tools.Cqs.Command;
using InetaAdmin.Database.Entities;
using InetaAdmin.Infrastructure.Write.Commands;

namespace InetaAdmin.Infrastructure.Write.CommandHandlers
{
    public class DeleteSpeakerCommandHandler: ICommandHandler<DeleteSpeakerCommand>
    {
        private readonly ITableClient _tableClient;

        public DeleteSpeakerCommandHandler(ITableClient tableClient)
        {
            _tableClient = tableClient;
        }

        public async void Handle(DeleteSpeakerCommand command)
        {
            var speaker = await _tableClient.GetItemOf<Speaker>(command.Id);
            _tableClient.DeleteItemOf<Speaker>(speaker);
        }
    }
}
