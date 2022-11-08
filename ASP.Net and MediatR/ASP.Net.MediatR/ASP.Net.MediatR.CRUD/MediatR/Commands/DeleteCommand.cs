using MediatR;
using ASP.Net.MediatR.CRUD.Result;

namespace ASP.Net.MediatR.CRUD.MediatR.Commands;

public class DeleteCommand<TId> : IRequest<ExecResult>
{
    public TId Id { get; set; } = default!;
	public DeleteCommand(TId id)
	{
		Id = id;
	}
}
