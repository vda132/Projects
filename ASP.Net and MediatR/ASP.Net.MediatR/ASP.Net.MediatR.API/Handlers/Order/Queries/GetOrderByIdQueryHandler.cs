using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.MediatR.Queries;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Queries;

namespace ASP.Net.MediatR.API.Handlers.Order.Queries;

public class GetOrderByIdQueryHandler : GetByIdQueryHandler<GetByIdQyery<OrderDto, int>, OrderDto, int>
{
    public GetOrderByIdQueryHandler(IOrderService service) : base(service) { }
}
