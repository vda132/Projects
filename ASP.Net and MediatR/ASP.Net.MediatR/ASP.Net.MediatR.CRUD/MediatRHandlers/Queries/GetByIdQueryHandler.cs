using ASP.Net.MediatR.CRUD.MediatR.Queries;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Abstract;
using ASP.Net.MediatR.CRUD.Result;
using ASP.Net.MediatR.CRUD.ServiceLayer;
using MediatR;

namespace ASP.Net.MediatR.CRUD.MediatRHandlers.Queries;

public class GetByIdQueryHandler<TQuery, TDto, TId> : BaseHandler<TDto, TId>, IRequestHandler<TQuery, ExecResult<TDto>>
    where TDto : BaseDto<TId>
    where TQuery : GetByIdQyery<TDto, TId>
{
    public GetByIdQueryHandler(ICRUDService<TDto, TId> service) : base(service) { }

    public async Task<ExecResult<TDto>> Handle(TQuery request, CancellationToken cancellationToken) =>
        await _service.GetAsync(request.Id, cancellationToken);
}
