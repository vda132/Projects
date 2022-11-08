using ASP.Net.MediatR.CRUD.Result;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net.MediatR.CRUD.DbLayer;

public class CRUDRepository<TContext, TEntity, TDto, TId> : ICRUDRepository<TDto, TId>
    where TContext : DbContext
    where TEntity : BaseModel<TId>
    where TDto : BaseDto<TId>

{
    private readonly TContext _context;
    private readonly IMapper _mapper;

    public CRUDRepository(TContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public virtual async Task<ExecResult<TId>> AddAsyns(TDto model, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<TDto, TEntity>(model);

            await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new ExecResult<TId> { Data = entity.Id, HasErrors = false, IsSystemError = false, Errors = null! };
        }
        catch (Exception ex)
        {
            return new ExecResult<TId> { Data = default!, HasErrors = true, IsSystemError = true, Errors = new string[] { ex.Message } };
        }
    }

    public virtual async Task<ExecResult<IEnumerable<TId>>> AddRangeAsync(IEnumerable<TDto> models, CancellationToken cancellationToken)
    {
        try
        {
            var entities = _mapper.Map<IEnumerable<TDto>, IEnumerable<TEntity>>(models);

            await _context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new ExecResult<IEnumerable<TId>> { Data = entities.Select(x => x.Id), HasErrors = false, IsSystemError = false, Errors = null! };
        }
        catch (Exception ex)
        {
            return new ExecResult<IEnumerable<TId>> { Data = default!, HasErrors = true, IsSystemError = true, Errors = new string[] { ex.Message } };
        }
    }

    public virtual async Task<ExecResult> DeleteAsync(TId id, CancellationToken cancellationToken)
    {
        try
        {
            var table = _context.Set<TEntity>();
            var entity = await table.FindAsync(new object[] { id! }, cancellationToken);

            if (entity is null)
                return new ExecResult { HasErrors = true, IsSystemError = false, Errors = new string[] { $"The item doesn`t exist in {nameof(table)}" } };

            table.Remove(entity!);

            await _context.SaveChangesAsync(cancellationToken);

            return new ExecResult { HasErrors = false, IsSystemError = false, Errors = null! };
        }
        catch (Exception ex)
        {
            return new ExecResult { HasErrors = true, IsSystemError = true, Errors = new string[] { ex.Message } };
        }
    }

    public virtual async Task<ExecResult> DeleteRangeAsync(IEnumerable<TId> ids, CancellationToken cancellationToken)
    {
        try
        {
            var table = _context.Set<TEntity>();
            var items = table.Where(x => ids.Contains(x.Id));

            if (items.Count() == 0)
                return new ExecResult { HasErrors = true, IsSystemError = false, Errors = new string[] { $"There are no items in table {nameof(table)}" } };

            table.RemoveRange(items);
            await _context.SaveChangesAsync(cancellationToken);

            return new ExecResult { HasErrors = false, IsSystemError = false, Errors = null! };
        }
        catch (Exception ex)
        {
            return new ExecResult { HasErrors = true, IsSystemError = true, Errors = new string[] { ex.Message } };
        }
    }

    public virtual async Task<ExecResult<TDto>> GetAsync(TId id, CancellationToken cancellationToken)
    {
        try
        {
            var table = _context.Set<TEntity>();
            var item = await table.FindAsync(new object[] { id! }, cancellationToken);

            if (item is null)
                return new ExecResult<TDto> { Data = default!, HasErrors = true, IsSystemError = false, Errors = new string[] { $"The item with current id doen`t exist in the table {nameof(table)}" } };

            var dto = _mapper.Map<TEntity, TDto>(item);

            return new ExecResult<TDto> { Data = dto, HasErrors = false, IsSystemError = false, Errors = null! };
        }
        catch (Exception ex)
        {
            return new ExecResult<TDto> { Data = null!, HasErrors = true, IsSystemError = true, Errors = new string[] { ex.Message } };
        }
    }

    public virtual async Task<ExecResult<IEnumerable<TDto>>> GetAsync(CancellationToken cancellationToken)
    {
        try
        {
            var table = _context.Set<TEntity>();
            var items = await table.AsQueryable<TEntity>().ToListAsync(cancellationToken);

            var dtos = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(items);

            return new ExecResult<IEnumerable<TDto>> { Data = dtos, HasErrors = false, IsSystemError = false, Errors = null! };
        }
        catch (Exception ex)
        {
            return new ExecResult<IEnumerable<TDto>> { Data = null!, HasErrors = true, IsSystemError = true, Errors = new string[] { ex.Message } };
        }
    }

    public virtual async Task<ExecResult> UpdateAsync(TDto model, CancellationToken cancellationToken)
    {
        try
        {
            var dbItem = await _context.Set<TEntity>().FindAsync(new object[] { model.Id! }, cancellationToken);
            
            if (dbItem is null)
                return new ExecResult { HasErrors = true, IsSystemError = false, Errors = new string[] { $"Item with id ({model.Id}) does not exist in ({typeof(TEntity).Name}) table" } };
            
            var result = _mapper.Map<TDto, TEntity>(model, dbItem);

            await _context.SaveChangesAsync(cancellationToken);
            
            return new ExecResult { HasErrors = false, IsSystemError = false, Errors = null! };
        }
        catch (Exception exc)
        {
            return new ExecResult { HasErrors = true, IsSystemError = true, Errors = new string[] { exc.Message } };
        }
    }
}
