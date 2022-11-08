using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Repositories;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.ServiceLayer;

namespace ASP.Net.MediatR.Services.Services;

public class OrderDetailService : CRUDService<IOrderDetailRepository, OrderDetailDto, int>, IOrderDetailService
{
    public OrderDetailService(IOrderDetailRepository repository) : base(repository) { }
}
