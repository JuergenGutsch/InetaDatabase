namespace Gos.Tools.Cqs.Command
{
    public interface ICommandPrecondition<in TCommand> where TCommand : ICommand
    {
        CommandPreconditionCheckResult Check(TCommand command);
    }
}