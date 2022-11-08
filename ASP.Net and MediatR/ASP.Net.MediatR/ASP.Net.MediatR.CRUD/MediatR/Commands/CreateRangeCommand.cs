using ASP.Net.MediatR.CRUD.Result;
using MediatR;

namespace ASP.Net.MediatR.CRUD.MediatR.Commands;

public class CreateRangeCommand<TDto, TId> : IRequest<ExecResult<IEnumerable<TId>>>
    where TDto : BaseDto<TId>
{
    public IEnumerable<TDto> Dtos { get; set; } = default!;
}
