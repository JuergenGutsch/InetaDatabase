using System.Threading.Tasks;

namespace Gos.Tools.Cqs.Command
{
    public interface IAsyncCommandHandler
    { }

    public interface IAsyncCommandHandler<in TCommand> : ICommandHandler where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }

    public interface IAsyncCommandHandler<in TCommand, TResult> : ICommandHandler where TCommand : ICommand
    {
        Task<TResult> HandleAsync(TCommand command);
    }
}