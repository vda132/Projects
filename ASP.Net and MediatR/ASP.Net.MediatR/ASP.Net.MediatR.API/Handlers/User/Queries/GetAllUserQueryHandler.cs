using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.MediatR.Queries;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Queries;

namespace ASP.Net.MediatR.API.Handlers.User.Queries;

public class GetAllUserQueryHandler : GetAllQueryHandler<GetAllQuery<UserDto, Guid>, UserDto, Guid>
{
    public GetAllUserQueryHandler(IUserService service) : base(service) { }
}
