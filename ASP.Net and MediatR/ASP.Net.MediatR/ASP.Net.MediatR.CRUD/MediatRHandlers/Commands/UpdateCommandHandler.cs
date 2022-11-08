using ASP.Net.MediatR.CRUD.MediatR.Commands;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Abstract;
using ASP.Net.MediatR.CRUD.Result;
using ASP.Net.MediatR.CRUD.ServiceLayer;
using MediatR;

namespace ASP.Net.MediatR.CRUD.MediatRHandlers.Commands;

public class UpdateCommandHandler<TQuery, TDto, TId> : BaseHandler<TDto, TId>, IRequestHandler<TQuery, ExecResult>
    where TDto : BaseDto<TId>
    where TQuery : UpdateCommand<TDto, TId>
{
    public UpdateCommandHandler(ICRUDService<TDto, TId> service) : base(service) { }

    public async Task<ExecResult> Handle(TQuery request, CancellationToken cancellationToken) =>
        await _service.UpdateAsync(request.Dto, cancellationToken);
}
