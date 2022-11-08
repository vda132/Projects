using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.MediatR.Queries;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Queries;

namespace ASP.Net.MediatR.API.Handlers.Order.Queries;

public class GetAllOrderQueryHandler : GetAllQueryHandler<GetAllQuery<OrderDto, int>, OrderDto, int>
{
    public GetAllOrderQueryHandler(IOrderService service) : base(service) { }
}
