namespace Mc2.CrudTest.Shared.Abstraction.Queries;

public interface IQueryDispatcher
{
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
}
