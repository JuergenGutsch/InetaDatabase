namespace Gos.Tools.Cqs.Command
{
    public interface ICommandHandler
    { }

    public interface ICommandHandler<in TCommand> : ICommandHandler where TCommand : ICommand
    {
        void Handle(TCommand command);
    }

    public interface ICommandHandler<in TCommand, out TResult> : ICommandHandler where TCommand : ICommand
    {
        TResult Handle(TCommand command);
    }
}