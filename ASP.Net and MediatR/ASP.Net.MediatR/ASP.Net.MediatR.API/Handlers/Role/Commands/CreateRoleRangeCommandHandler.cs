using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.MediatR.Commands;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Commands;

namespace ASP.Net.MediatR.API.Handlers.Role.Commands;

public class CreateRoleRangeCommandHandler : CreateRangeCommandHandler<CreateRangeCommand<RoleDto, int>, RoleDto, int>
{
    public CreateRoleRangeCommandHandler(IRoleService service) : base(service)
    {
    }
}
