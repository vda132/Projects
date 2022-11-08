using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.MediatR.Commands;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Commands;

namespace ASP.Net.MediatR.API.Handlers.Role.Commands;

public class DeleteRoleCommandHandler : DeleteCommandHandler<DeleteCommand<int>, RoleDto, int>
{
    public DeleteRoleCommandHandler(IRoleService service) : base(service) { }
}
