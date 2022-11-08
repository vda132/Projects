using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.MediatR.Queries;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Queries;

namespace ASP.Net.MediatR.API.Handlers.Role.Queries;

public class GetRoleByIdQueryHandler : GetByIdQueryHandler<GetByIdQyery<RoleDto, int>, RoleDto, int>
{
    public GetRoleByIdQueryHandler(IRoleService service) : base(service) { }
}
