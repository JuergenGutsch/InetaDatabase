namespace Gos.Tools.Cqs.Query
{
    public interface IHandleQuery<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        TResult Execute(TQuery query);
    }
}