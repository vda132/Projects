using ASP.Net.MediatR.CRUD.MediatR.Commands;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Abstract;
using ASP.Net.MediatR.CRUD.Result;
using ASP.Net.MediatR.CRUD.ServiceLayer;
using AutoMapper;
using MediatR;

namespace ASP.Net.MediatR.CRUD.MediatRHandlers.Commands;

public class CreateRangeCommandHandler<TQuery, TDto, TId> : BaseHandler<TDto, TId>, IRequestHandler<TQuery, ExecResult<IEnumerable<TId>>>
    where TDto : BaseDto<TId>
    where TQuery : CreateRangeCommand<TDto, TId>
{
    public CreateRangeCommandHandler(ICRUDService<TDto, TId> service) : base(service) { }

    public virtual async Task<ExecResult<IEnumerable<TId>>> Handle(TQuery request, CancellationToken cancellationToken) =>
        await _service.AddRangeAsync(request.Dtos, cancellationToken);
}
