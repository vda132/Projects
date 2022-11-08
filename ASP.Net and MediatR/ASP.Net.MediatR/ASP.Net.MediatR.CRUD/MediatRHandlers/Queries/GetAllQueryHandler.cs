using ASP.Net.MediatR.CRUD.MediatR.Queries;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Abstract;
using ASP.Net.MediatR.CRUD.Result;
using ASP.Net.MediatR.CRUD.ServiceLayer;
using MediatR;

namespace ASP.Net.MediatR.CRUD.MediatRHandlers.Queries;

public class GetAllQueryHandler<TQuery, TDto, TId> : BaseHandler<TDto, TId>, IRequestHandler<TQuery, ExecResult<IEnumerable<TDto>>>
    where TDto : BaseDto<TId>
    where TQuery : GetAllQuery<TDto, TId>
{
    public GetAllQueryHandler(ICRUDService<TDto, TId> service) : base(service) { }

    public virtual async Task<ExecResult<IEnumerable<TDto>>> Handle(TQuery request, CancellationToken cancellationToken) =>
        await _service.GetAsync(cancellationToken);
}
