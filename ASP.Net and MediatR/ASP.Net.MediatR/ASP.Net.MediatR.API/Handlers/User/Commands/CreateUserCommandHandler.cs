using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.MediatR.Commands;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Commands;

namespace ASP.Net.MediatR.API.Handlers.User.Commands;

public class CreateOrderCommandHandler : CreateCommandHandler<CreateCommand<UserDto, Guid>, UserDto, Guid>
{
    public CreateOrderCommandHandler(IUserService service) : base(service) { }
}
