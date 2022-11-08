using ASP.Net.MediatR.CRUD.DbLayer;
using ASP.Net.MediatR.CRUD.Result;

namespace ASP.Net.MediatR.CRUD.ServiceLayer;

public class CRUDService<TRepo, TDto, TId> : ICRUDService<TDto, TId>
    where TRepo : ICRUDRepository<TDto, TId>
    where TDto : BaseDto<TId>
{
    private readonly TRepo _repository;

    public CRUDService(TRepo repository) =>
        _repository = repository;

    public virtual async Task<ExecResult<TId>> AddAsyns(TDto model, CancellationToken cancellationToken) =>
        await _repository.AddAsyns(model, cancellationToken);

    public virtual async Task<ExecResult<IEnumerable<TId>>> AddRangeAsync(IEnumerable<TDto> models, CancellationToken cancellationToken) =>
        await _repository.AddRangeAsync(models, cancellationToken);

    public virtual async Task<ExecResult> DeleteAsync(TId id, CancellationToken cancellationToken) =>
        await _repository.DeleteAsync(id, cancellationToken);

    public virtual async Task<ExecResult> DeleteRangeAsync(IEnumerable<TId> ids, CancellationToken cancellationToken) =>
        await _repository.DeleteRangeAsync(ids, cancellationToken);

    public virtual async Task<ExecResult<TDto>> GetAsync(TId id, CancellationToken cancellationToken) => 
        await _repository.GetAsync(id, cancellationToken);

    public virtual async Task<ExecResult<IEnumerable<TDto>>> GetAsync(CancellationToken cancellationToken) =>
        await _repository.GetAsync(cancellationToken);

    public virtual async Task<ExecResult> UpdateAsync(TDto model, CancellationToken cancellationToken) =>
        await _repository.UpdateAsync(model, cancellationToken);
}
