using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.MediatR.Commands;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Commands;
using ASP.Net.MediatR.CRUD.ServiceLayer;

namespace ASP.Net.MediatR.API.Handlers.Role.Commands;

public class CreateRoleCommandHandler : CreateCommandHandler<CreateCommand<RoleDto, int>, RoleDto, int>
{
    public CreateRoleCommandHandler(IRoleService service) : base(service) { }
}
