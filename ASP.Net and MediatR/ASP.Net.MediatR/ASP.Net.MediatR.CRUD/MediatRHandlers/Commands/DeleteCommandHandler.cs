using ASP.Net.MediatR.CRUD.MediatR.Commands;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Abstract;
using ASP.Net.MediatR.CRUD.Result;
using ASP.Net.MediatR.CRUD.ServiceLayer;
using MediatR;

namespace ASP.Net.MediatR.CRUD.MediatRHandlers.Commands;

public class DeleteCommandHandler<TQuery, TDto, TId> : BaseHandler<TDto, TId>, IRequestHandler<TQuery, ExecResult>
    where TQuery : DeleteCommand<TId>
{
    public DeleteCommandHandler(ICRUDService<TDto, TId> service) : base(service) { }

    public virtual async Task<ExecResult> Handle(TQuery request, CancellationToken cancellationToken) =>
        await _service.DeleteAsync(request.Id, cancellationToken);
}
