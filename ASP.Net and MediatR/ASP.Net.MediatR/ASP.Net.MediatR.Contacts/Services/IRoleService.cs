using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.CRUD.ServiceLayer;

namespace ASP.Net.MediatR.Contacts.Services;

public interface IRoleService : ICRUDService<RoleDto, int>
{
}
