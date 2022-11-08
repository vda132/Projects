using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Repositories;
using ASP.Net.MediatR.CRUD.DbLayer;
using ASP.Net.MediatR.DAL.Models;
using AutoMapper;

namespace ASP.Net.MediatR.DAL.Repositories;

public class RoleRepository : CRUDRepository<ApplicationDbContext, Role, RoleDto, int>, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
}
