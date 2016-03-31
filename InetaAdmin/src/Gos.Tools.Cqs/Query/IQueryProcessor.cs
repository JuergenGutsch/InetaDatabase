using System.Threading.Tasks;

namespace Gos.Tools.Cqs.Query
{
    public interface IQueryProcessor
    {
        TResult Process<TResult>(IQuery<TResult> query);
        Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query);
    }
}