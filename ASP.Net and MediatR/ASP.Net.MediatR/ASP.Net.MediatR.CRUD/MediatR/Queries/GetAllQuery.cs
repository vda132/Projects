using ASP.Net.MediatR.CRUD.Result;
using MediatR;

namespace ASP.Net.MediatR.CRUD.MediatR.Queries;

public class GetAllQuery<TDto, TId> : IRequest<ExecResult<IEnumerable<TDto>>>
    where TDto : BaseDto<TId>
{
}
