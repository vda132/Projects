using ASP.Net.MediatR.CRUD.Result;
using MediatR;

namespace ASP.Net.MediatR.CRUD.MediatR.Commands;

public class UpdateCommand<TDto, TId> : IRequest<ExecResult>
    where TDto : BaseDto<TId>
{
    public TDto Dto { get; set; } = default!;
    public UpdateCommand(TDto dto)
    {
        Dto = dto;
    }
}
