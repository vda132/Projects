using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.MediatR.Queries;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Queries;

namespace ASP.Net.MediatR.API.Handlers.OrderDetail.Queries;

public class GetAllOrderDetailQueryHandler : GetAllQueryHandler<GetAllQuery<OrderDetailDto, int>, OrderDetailDto, int>
{
    public GetAllOrderDetailQueryHandler(IOrderDetailService service) : base(service) { }
}
