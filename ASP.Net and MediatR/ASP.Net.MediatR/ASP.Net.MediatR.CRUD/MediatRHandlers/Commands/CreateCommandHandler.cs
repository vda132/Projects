using ASP.Net.MediatR.CRUD.MediatR.Commands;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Abstract;
using ASP.Net.MediatR.CRUD.Result;
using ASP.Net.MediatR.CRUD.ServiceLayer;
using MediatR;

namespace ASP.Net.MediatR.CRUD.MediatRHandlers.Commands;

public class CreateCommandHandler<TQuery, TDto, TId> : BaseHandler<TDto, TId>, IRequestHandler<TQuery, ExecResult<TId>>
    where TQuery : CreateCommand<TDto, TId>
    where TDto : BaseDto<TId>
{
    public CreateCommandHandler(ICRUDService<TDto, TId> service) : base(service) { }

    public virtual async Task<ExecResult<TId>> Handle(TQuery request, CancellationToken cancellationToken) =>
        await _service.AddAsyns(request.Dto, cancellationToken);
}
