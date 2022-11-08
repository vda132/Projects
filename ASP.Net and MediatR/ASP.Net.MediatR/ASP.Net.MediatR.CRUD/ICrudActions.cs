using ASP.Net.MediatR.CRUD.Result;

namespace ASP.Net.MediatR.CRUD;

public interface ICrudActions<T, TId>
{
    Task<ExecResult<TId>> AddAsyns(T model, CancellationToken cancellationToken);
    Task<ExecResult<IEnumerable<TId>>> AddRangeAsync(IEnumerable<T> models, CancellationToken cancellationToken);
    Task<ExecResult<T>> GetAsync(TId id, CancellationToken cancellationToken);
    Task<ExecResult<IEnumerable<T>>> GetAsync(CancellationToken cancellationToken);
    Task<ExecResult> UpdateAsync(T model, CancellationToken cancellationToken);
    Task<ExecResult> DeleteAsync(TId id, CancellationToken cancellationToken);
    Task<ExecResult> DeleteRangeAsync(IEnumerable<TId> ids, CancellationToken cancellationToken);
}
