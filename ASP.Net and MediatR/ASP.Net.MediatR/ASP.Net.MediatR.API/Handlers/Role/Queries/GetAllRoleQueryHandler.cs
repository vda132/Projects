using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.MediatR.Queries;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Queries;

namespace ASP.Net.MediatR.API.Handlers.Role.Queries;

public class GetAllRoleQueryHandler : GetAllQueryHandler<GetAllQuery<RoleDto, int>, RoleDto, int>
{
    public GetAllRoleQueryHandler(IRoleService service) : base(service) { }
}
