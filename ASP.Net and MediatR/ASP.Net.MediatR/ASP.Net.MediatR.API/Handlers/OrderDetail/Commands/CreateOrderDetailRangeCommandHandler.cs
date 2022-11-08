using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.MediatR.Commands;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Commands;

namespace ASP.Net.MediatR.API.Handlers.OrderDetail.Commands;

public class CreateOrderDetailRangeCommandHandler : CreateRangeCommandHandler<CreateRangeCommand<OrderDetailDto, int>, OrderDetailDto, int>
{
    public CreateOrderDetailRangeCommandHandler(IOrderDetailService service) : base(service) { }
}
