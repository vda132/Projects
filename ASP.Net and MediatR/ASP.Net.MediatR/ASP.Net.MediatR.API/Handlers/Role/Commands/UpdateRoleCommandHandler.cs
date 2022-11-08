using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.MediatR.Commands;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Commands;

namespace ASP.Net.MediatR.API.Handlers.Role.Commands;

public class UpdateRoleCommandHandler : UpdateCommandHandler<UpdateCommand<RoleDto, int>, RoleDto, int>
{
    public UpdateRoleCommandHandler(IRoleService service) : base(service) { }
}
