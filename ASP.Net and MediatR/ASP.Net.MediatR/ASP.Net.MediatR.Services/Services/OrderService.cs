using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Repositories;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.ServiceLayer;

namespace ASP.Net.MediatR.Services.Services;

public class OrderService : CRUDService<IOrderRepository, OrderDto, int>, IOrderService
{
    public OrderService(IOrderRepository repository) : base(repository) { }
}
