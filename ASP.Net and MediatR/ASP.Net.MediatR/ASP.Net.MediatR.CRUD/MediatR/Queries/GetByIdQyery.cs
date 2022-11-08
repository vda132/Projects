using ASP.Net.MediatR.CRUD.Result;
using MediatR;

namespace ASP.Net.MediatR.CRUD.MediatR.Queries;

public class GetByIdQyery<TDto, TId> : IRequest<ExecResult<TDto>>
    where TDto : BaseDto<TId>
{
    public TId Id { get; set; } = default!;
    public GetByIdQyery(TId id)
    {
        Id = id;
    }
}
