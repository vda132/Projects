using ASP.Net.MediatR.CRUD.Result;
using MediatR;

namespace ASP.Net.MediatR.CRUD.MediatR.Commands;

public class CreateCommand<TDto, TId> : IRequest<ExecResult<TId>>
    where TDto : BaseDto<TId>
{
    public TDto Dto { get; set; } = default!;

    public CreateCommand(TDto dto)
    {
        Dto = dto;
    }
}
