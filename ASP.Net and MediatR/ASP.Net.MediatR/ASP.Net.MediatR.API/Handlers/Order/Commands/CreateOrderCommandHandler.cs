using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.MediatR.Commands;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Commands;

namespace ASP.Net.MediatR.API.Handlers.Order.Commands;

public class CreateOrderCommandHandler : CreateCommandHandler<CreateCommand<OrderDto, int>, OrderDto, int>
{
    public CreateOrderCommandHandler(IOrderService service) : base(service) { }
}
